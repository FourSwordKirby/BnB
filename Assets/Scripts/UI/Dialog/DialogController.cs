using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;
using System;


public class DialogController : MonoBehaviour
{
    public DialogUI dialogUI;
	public GameManager gameManager;
	public TwineParser twineParser;

    public TwineStory currentStory;

    public AudioClip clickSound;
    
    private bool storyCompleted;

	public bool IgnoreEmptyLines = true;

    private List<string> lines;
    private int currentLine;
    private string currentText;

	/* Contains mapping for which displayed option number maps to 
	 * Twine option number 
	 */
	private List<int> validOptionMap;

	private static int numMaxOptions = 5;

    public delegate void OnDisplayComplete();
    public OnDisplayComplete CleanupFunction;

    public void advanceStory()
    {
        if (!dialogUI.dialogCompleted())
        {
            dialogUI.resolveDialog();
            return;
        }

        if (currentLine < lines.Count)
        {
            string line;
            string instructions;
            do
            {
                line = "";
                instructions = "";

                line = lines[currentLine];
				                
				if (twineParser.IsInstruction(line))
                {
                    instructions = line.Substring(line.IndexOf("%"), line.Substring(1).IndexOf("%")+1);
					ApplyInstructions(instructions);
                    currentLine++;
                }

                if (twineParser.IsReaction(line))
                {
                    instructions = line.Substring(line.IndexOf("#") + 1, line.Substring(1).IndexOf("#"));
                    ApplyReaction(instructions);
                    currentLine++;
                }

                if (twineParser.IsSound(line))
                {
                    instructions = line.Substring(line.IndexOf("$") + 1, line.Substring(1).IndexOf("$"));
                    ApplySound(instructions);
                    currentLine++;
                }

                if (twineParser.IsBGM(line))
                {
                    instructions = line.Substring(line.IndexOf("~") + 1, line.Substring(1).IndexOf("~"));
                    ApplyBGM(instructions);
                    currentLine++;
                }

                if (twineParser.IsEnding(line))
                {
                    instructions = line.Substring(line.IndexOf("&") + 1, line.Substring(1).IndexOf("&"));
                    ApplyEnding(instructions);
                }
			} while (instructions != "");

            string speakerName = "";
            string dialog = "";
			if (line.IndexOf(":") >= 0 && line.IndexOf(":") <= "BEAUREGARD".Length)
			{
                speakerName = line.Substring(0, line.IndexOf(":"));
                dialog = line.Substring(line.IndexOf(":") + 2);
            }
            else
            {
                dialog = line;
            }
            dialogUI.displayDialog(speakerName, dialog);
            currentLine++;
        }
        if (currentLine == lines.Count)
        {
			if (currentStory.State == TwineStoryState.Complete)
				storyCompleted = true;
			else
            	CleanupFunction = DisplayOptions;
        }
    }

	private void ApplyInstructions(string instructions) {
		string[] instrList = instructions.Split(',');

		int numCharacters;
		// TODO Replace this with a twineParser.IsValidInstruction()
		if (!Int32.TryParse(instrList[0].Substring(1), out numCharacters)) {
			// TODO: Handle error somehow
			Debug.Log("ERROR! Malformed input!");
            return;
		}

		//Debug.Log ("Number characters for this scene: " + numCharacters);

		dialogUI.clearLoveInterests ();



		for (int i = 0; i < numCharacters; i++) {
			GameManager.LoveInterestName name = twineParser.ParseName(twineParser.TrimTag(instrList [3 * i + 1]));
			DialogUI.ImagePositon position = twineParser.ParsePos(twineParser.TrimTag(instrList [3 * i + 2]));
			LoveInterest.Emotion emotion = twineParser.ParseEmotion(twineParser.TrimTag(instrList [3 * i + 3]));

            dialogUI.displayLoveInterest(gameManager.getLoveInterest(name), emotion, position);
		}
	}

    private void ApplyReaction(string reaction)
    {
        string[] instrList = reaction.Split(',');


        int restrictionVar = twineParser.ParseVariable(instrList[0]);
        int variableChange = int.Parse(instrList[1]);

        restrictionVar += variableChange;

        twineParser.ApplyVariable(instrList[0], restrictionVar);
    }

	private List<string> FilterValidOptions(List<UnityTwine.TwineLink> options) {
		List<string> validOptions = new List<string>();
		this.validOptionMap.Clear ();

		for (int i = 0; i < options.Count; i++) {
			string optionText = options[i].Text;
			if (twineParser.HasRestriction (optionText)) {
				if (twineParser.PassesRestriction (optionText)) {
					validOptions.Add (twineParser.TrimRestriction (optionText));
					validOptionMap.Add (i);
				}
			} else {
				validOptions.Add (optionText);
				validOptionMap.Add (i);
			}
		}
		return validOptions;
	}

    private void ApplySound(string soundName)
    {
        GameManager.sfxManager.play(soundName);
    }

    private void ApplyBGM(string instructions)
    {
        int mood = int.Parse(instructions);
        GameManager.bgmManager.mood = mood;
    }

    private void ApplyEnding(string instructions)
    {
        /***** THIS WILL BE CALLED TO START AN ENDING, IT INVOLVES ENDING THE CURRENT CONVERSATION AND TRANSITIONING INTO THE APPROPRIATE
             * BACKGROUND/MUSIC etc. combination*****/
    }

    private void DisplayOptions()
    {
		List<string> optionsToDisplay = FilterValidOptions (currentStory.Links);
		if (optionsToDisplay.Count > numMaxOptions)
			Debug.Log ("ERROR: Cannot display all options");

		//Debug.Log ("Num of valid options=" + optionsToDisplay.Count); 

		for (int i = 0; i < optionsToDisplay.Count; i++) {
			dialogUI.enableOption (i);
			//Debug.Log("Displaying option " + i + ": " + currentStory.Links[i].Text);
			dialogUI.displayOption (optionsToDisplay[i], i);
            Debug.Log(optionsToDisplay[i]);
		}
    }

	private void HideOptions()
	{
		for (int i = 0; i < numMaxOptions; i++)
		{
			dialogUI.disableOption(i);
		}
	}

    public void selectOption(int dispOptionNum)
    {
		int twineOptionNum = validOptionMap [dispOptionNum];
		if (twineOptionNum  >= currentStory.Links.Count)
        {
            Debug.Log("This option is not in range");
            return;
        }

        //Debug.Log("You chose " + currentStory.Links[option].Text);

        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
		currentStory.Advance (currentStory.Links[twineOptionNum]);
    }

	void Story_OnStateChanged(TwineStoryState state) {
		
		if (state == TwineStoryState.Idle || state == TwineStoryState.Complete) {
			//dialogUI.displayDialog ("", this.currentText);
			advanceStory ();
			//CleanupFunction = Close 
		} else if (state == TwineStoryState.Playing) {
            //Make sure we don't display options prematurely
            HideOptions();
		}
		
		//Debug.Log ("Now in state " + state);
	}

	void Story_OnOutput(TwineOutput output) {

		if (output is TwineText) {
			var text = (TwineText)output;
			if (IgnoreEmptyLines && text.Text.Trim ().Length < 1)
				return;
			lines.Add (text.Text);
		}
	}

    void Awake()
    {
        //Initializing internal variables
        this.lines = new List<string>();
		this.validOptionMap = new List<int> ();
    }

	public void StartConversation(TwineStory story) {

		Debug.Log ("Starting story: " + story);

		this.currentStory = story;

		storyCompleted = false;
		
		/* Register UnityTwine callback functions */
		this.currentStory.OnOutput += Story_OnOutput;
		this.currentStory.OnStateChanged += Story_OnStateChanged;

		this.currentStory.Begin();
	}
    public void CloseConversation()
    {
        //Used to ensure we don't screw up and throw an error going to a previous story
        currentStory.Reset();
        currentStory.OnOutput -= Story_OnOutput;
        currentStory.OnStateChanged -= Story_OnStateChanged;


        lines.Clear();
        currentLine = 0;

        HideOptions();
        dialogUI.clearLoveInterests();
        dialogUI.clearDialogBox();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			if (storyCompleted && dialogUI.dialogCompleted()) {
                GameManager.EndConversation();
			}
            advanceStory();
        }

        if (dialogUI.dialogCompleted() && CleanupFunction != null)
        {
            CleanupFunction();
            CleanupFunction = null;
        }
    }
}
