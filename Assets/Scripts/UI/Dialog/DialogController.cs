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
//
//    private bool IsReaction(string line)
//    {
//        return line[0] == '#';
//    }

    private void ApplyReaction(string reaction)
    {
        string[] instrList = reaction.Split(',');


        int restrictionVar = twineParser.ParseVariable(instrList[0]);
        int variableChange = int.Parse(instrList[1]);

        restrictionVar += variableChange;

        twineParser.SetVariable(instrList[0], restrictionVar);
    }

    private void DisplayOptions()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < currentStory.Links.Count)
            {
                if (twineParser.PassesRestriction(currentStory.Links[i].Text))
                {
                    dialogUI.enableOption(i);
                    //Debug.Log("Displaying option " + i + ": " + currentStory.Links[i].Text);
                    dialogUI.displayOption(currentStory.Links[i].Text, i);
                }
            }
            else
                dialogUI.disableOption(i);
        }
    }

	private void HideOptions()
	{
		for (int i = 0; i < 3; i++)
		{
			dialogUI.disableOption(i);
		}
	}

    public void selectOption(int option)
    {
        if (option >= currentStory.Links.Count)
        {
            Debug.Log("This option is not in range");
            return;
        }

        //Debug.Log("You chose " + currentStory.Links[option].Text);

        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
		currentStory.Advance (currentStory.Links[option]);
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
			Debug.Log ("Text: " + output.Text);
			
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
