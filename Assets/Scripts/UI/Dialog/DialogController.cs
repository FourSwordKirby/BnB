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
				                
				if (IsInstruction(line))
                {
                    instructions = line.Substring(line.IndexOf("%"), line.Substring(1).IndexOf("%")+1);
					ApplyInstructions(instructions);
                    currentLine++;
                }
			} while (instructions != "");

            string speakerName = "";
            string dialog = "";
            if (line.IndexOf(":") >= 0)
            {
                speakerName = line.Substring(0, line.IndexOf(":"));
                dialog = line.Substring(line.IndexOf(":") + 2);
            }
            else
            {
                dialog = line;
            }

            /*
            if (dialog.IndexOf("//") >= 0)
            {
                dialog = dialog.Substring(dialog.IndexOf("//") + 2, dialog.IndexOf("//", 2)-2);
                dialogUI.displayItalics();
            }
            else
                dialogUI.displayNormal();
             */

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

	private string TrimTag(string tag) {
		//Debug.Log ("Tag to be trimmed: " + tag);
		return tag.Substring (2, tag.IndexOf (">") - 2);
	}
		
	private GameManager.LoveInterestName ParseName(string tagName) {

		switch (tagName) {
		case "beau":
			return GameManager.LoveInterestName.Beauregard;
			// TODO: add other cases as Sam writes them
		default:
			Debug.Log ("ERROR: Malformed Tag Name input: " + tagName);
			break;
		}
		return GameManager.LoveInterestName.Beauregard;
	}

	private DialogUI.ImagePositon ParsePos(string tagPos) {

		switch (tagPos) {
		case "farleft":
			return DialogUI.ImagePositon.FarLeft;
		case "nearleft":
			return DialogUI.ImagePositon.NearLeft;
		case "center":
			return DialogUI.ImagePositon.Center;
		case "nearright":
			return DialogUI.ImagePositon.NearRight;
		case "farright":
			return DialogUI.ImagePositon.FarRight;
			// TODO: add other cases as Sam writes them
		default:
			Debug.Log ("ERROR: Malformed Tag Pos input: " + tagPos);
			break;
		}
		return DialogUI.ImagePositon.Center;
	}

	private LoveInterest.Emotion ParseEmotion(string tagEmotion) {
		switch (tagEmotion) {
		case "neutral":
			return LoveInterest.Emotion.Neutral;
		case "smile":
			return LoveInterest.Emotion.Happy;
		case "blush":
			return LoveInterest.Emotion.Flattered;
		case "angry":
			return LoveInterest.Emotion.Angry;
		case "frown":
			return LoveInterest.Emotion.Sad;
			// TODO: add other cases as Sam writes them
		default:
			Debug.Log ("ERROR: Malformed Tag Emotion input: " + tagEmotion);
			break;
		}
		return LoveInterest.Emotion.Neutral;
	}

	private void ApplyInstructions(string instructions) {
		//Debug.Log ("Instructions: " + instructions);

		string[] instrList = instructions.Split(',');

		int numCharacters;
		if (!Int32.TryParse(instrList[0].Substring(1), out numCharacters)) {
			// TODO: Handle error somehow
			Debug.Log("ERROR! Malformed input!");
		}

		//Debug.Log ("Number characters for this scene: " + numCharacters);

		dialogUI.clearLoveInterests ();

		for (int i = 0; i < numCharacters; i++) {
			GameManager.LoveInterestName name = ParseName(TrimTag(instrList [3 * i + 1]));
			DialogUI.ImagePositon position = ParsePos(TrimTag(instrList [3 * i + 2]));
			LoveInterest.Emotion emotion = ParseEmotion(TrimTag(instrList [3 * i + 3]));

            dialogUI.displayLoveInterest(gameManager.getLoveInterest(name), emotion, position);
		}
	}

    private void DisplayOptions()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < currentStory.Links.Count)
            {
                dialogUI.enableOption(i);
				Debug.Log ("Displaying option " + i + ": " + currentStory.Links [i].Text);
                dialogUI.displayOption(currentStory.Links[i].Text, i);
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

        Debug.Log("You chose " + currentStory.Links[option].Text);

        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
		currentStory.Advance (currentStory.Links[option]);
    }

	void Clear() {
		HideOptions ();
		// TODO: Clear dialogue box
	}

	void CloseConversation() {
		HideOptions ();
		dialogUI.clearLoveInterests ();
        dialogUI.clearDialogBox();
        gameManager.mapControls.displayControls();
	}

	void Story_OnStateChanged(TwineStoryState state) {
		//Debug.Log ("State change: " + state);
		if (state == TwineStoryState.Idle || state == TwineStoryState.Complete) {
			//dialogUI.displayDialog ("", this.currentText);
			advanceStory ();
			//CleanupFunction = Close 
		} else if (state == TwineStoryState.Playing) {
			Clear ();
			// TODO: Clear output data from previous state
		}
		
		//Debug.Log ("Now in state " + state);
	}

	private bool IsInstruction(string line) {
		return line [0] == '%';
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
    }

	void Start() {
		// TODO: This is just here for testing
        //this.currentStory = loadedLoveInterest.LoveInterestStory;

		/* Register UnityTwine callback functions */
		/*
        this.currentStory.OnOutput += Story_OnOutput;
		this.currentStory.OnStateChanged += Story_OnStateChanged;

		this.currentStory.Begin();

        dialogUI.displayLoveInterest(loadedLoveInterest, LoveInterest.Emotion.Happy);
         */
	}

	public void StartConversation(TwineStory story) {

        //Visual cleanup
        gameManager.mapControls.hideControls();

		this.currentStory = story;

		storyCompleted = false;
		
		/* Register UnityTwine callback functions */
		this.currentStory.OnOutput += Story_OnOutput;
		this.currentStory.OnStateChanged += Story_OnStateChanged;

		this.currentStory.Begin();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			if (storyCompleted && dialogUI.dialogCompleted()) {
				CloseConversation ();
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
