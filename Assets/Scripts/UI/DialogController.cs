using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;
using System;


public class DialogController : MonoBehaviour
{
    public DialogUI dialogUI;

    public LoveInterest loadedLoveInterest;
    private TwineStory currentStory;
    private bool storyCompleted;

	public bool IgnoreEmptyLines = true;

    private List<string> lines;
    private int currentLine;
    private string currentText;
	private bool newPassage = true;

    public delegate void OnDisplayComplete();
    public OnDisplayComplete CleanupFunction;

    public void advanceStory()
    {
        if (currentLine < lines.Count)
        {
            string line;
            string instructions;
            do
            {
                line = "";
                instructions = "";

                Debug.Log(currentLine);
                line = lines[currentLine];

                //Uncomment this area when instructions are put on a seperate line from the dialog
                /*
                if (line[0] == '[')
                {
                    instructions = line.Substring(line.IndexOf("["), line.IndexOf("]"));
                    //ApplyInstructions(ParseInstructions(instructions));
                    currentLine++;
                }*/
            } while (instructions != "");


            string speakerName = line.Substring(0, line.IndexOf(":"));
            string dialog = line.Substring(line.IndexOf(":") + 2);

            dialogUI.displayDialog(speakerName, dialog);
            currentLine++;
        }
        if (currentLine == lines.Count)
        {
            CleanupFunction = DisplayOptions;
        }
    }

	private DialogState ParseInstructions(string instructions) {

		/* [# characters, <char 1 name>, <char 1 position>, <char 1 emotion>, <char 2 name>.....etc] */

		// TODO: Parse a string of instructions from a twee to a usable DialogState data structure
		DialogState state = new DialogState();

		string[] instrList = instructions.Split(',');

		int numCharacters;
		if (!Int32.TryParse(instrList[0].Substring(1), out numCharacters)) {
			// TODO: Handle error somehow
			Debug.Log("ERROR! Malformed input!");
		}

		Debug.Log ("Number characters for this scene: " + numCharacters);

		for (int i = 0; i < numCharacters; i++) {
			string name = instrList [3 * i + 1];
			string position = instrList [3 * i + 2];
			string emotion = instrList [3 * i + 2];
			// TODO: way way more code to parse info into state that we want it
		}

		return state;
	}

	private void ApplyInstructions(DialogState state) {
		// TODO: Apply instructions from a DialogState data struct to the current scene
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

		currentStory.Advance (currentStory.Links[option]);
    }

	void Clear() {
		HideOptions ();
		// TODO: Clear dialogue box
	}

	void Story_OnStateChanged(TwineStoryState state) {
		Debug.Log ("Now in state " + state);

		if (state == TwineStoryState.Complete) {
			// TODO: What do we do when no more links?
		}
		if (state == TwineStoryState.Idle) {
			//dialogUI.displayDialog ("", this.currentText);
		}
		if (state == TwineStoryState.Playing) {
			newPassage = true;
			Clear ();

			// TODO: Clear output date from previous state
		}
		
		//Debug.Log ("Now in state " + state);
	}

	void Story_OnOutput(TwineOutput output) {
		//Debug.Log ("Recieved output " + output);

		if (output is TwineText) {
			
			var text = (TwineText)output;
			if (IgnoreEmptyLines && text.Text.Trim ().Length < 1)
				return;

			lines.Add (text.Text);

			// Frojo to Roger: this is kind of ugly but works for now?
			if (newPassage) {
				newPassage = false;
				advanceStory ();
			}
		}
	}

    void Awake()
    {
        //Initializing internal variables
        this.lines = new List<string>();
        this.currentLine = 0;
    }

	void Start() {
		// TODO: This is just here for testing
        this.currentStory = loadedLoveInterest.LoveInterestStory;

		/* Register UnityTwine callback functions */
		this.currentStory.OnOutput += Story_OnOutput;
		this.currentStory.OnStateChanged += Story_OnStateChanged;

		this.currentStory.Begin();

        dialogUI.displayLoveInterest(loadedLoveInterest, LoveInterest.Emotion.Happy);
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            advanceStory();
        }

        if (dialogUI.dialogCompleted() && CleanupFunction != null)
        {
            Debug.Log("made it here");
            CleanupFunction();
            CleanupFunction = null;
        }
    }
}
