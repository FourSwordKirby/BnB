﻿using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;
using System;


public class DialogController : MonoBehaviour
{
    public DialogUI dialogUI;

    public LoveInterest loadedLoveInterest;
    public TwineStory currentStory;
    private bool storyCompleted;

	public bool IgnoreEmptyLines = true;

    private List<string> lines;
    private int currentLine;
    private string currentText;

    public delegate void OnDisplayComplete();
    public OnDisplayComplete CleanupFunction;

    public void advanceStory()
    {
        if (currentLine < lines.Count)
        {
            if (!dialogUI.dialogCompleted())
            {
                dialogUI.resolveDialog();
                return;
            }

            string line;
            string instructions;
            do
            {
                line = "";
                instructions = "";

                line = lines[currentLine];

                //Uncomment this area when instructions are put on a seperate line from the dialog
                
				if (IsInstruction(line))
                {
                    instructions = line.Substring(line.IndexOf("%"), line.Substring(1).IndexOf("%")+1);
					ApplyInstructions(instructions);
                    currentLine++;
                }
			} while (instructions != "");
            
			//line = lines [currentLine];

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

	private string TrimTag(string tag) {
		Debug.Log ("Tag to be trimmed: " + tag);
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
		Debug.Log ("Instructions: " + instructions);

		string[] instrList = instructions.Split(',');

		int numCharacters;
		if (!Int32.TryParse(instrList[0].Substring(1), out numCharacters)) {
			// TODO: Handle error somehow
			Debug.Log("ERROR! Malformed input!");
		}

		Debug.Log ("Number characters for this scene: " + numCharacters);

		for (int i = 0; i < numCharacters; i++) {
			GameManager.LoveInterestName name = ParseName(TrimTag(instrList [3 * i + 1]));
			DialogUI.ImagePositon position = ParsePos(TrimTag(instrList [3 * i + 2]));
			LoveInterest.Emotion emotion = ParseEmotion(TrimTag(instrList [3 * i + 3]));
			// TODO: Change it to display any love interest, not just loaded one
            dialogUI.displayLoveInterest(GameManager.getLoveInterest(name), emotion, position);
			// TODO: Now display it
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

		currentStory.Advance (currentStory.Links[option]);
    }

	void Clear() {
		HideOptions ();
		// TODO: Clear dialogue box
	}

	void Story_OnStateChanged(TwineStoryState state) {
        if (state == TwineStoryState.Complete || state == TwineStoryState.Idle)
        {
			//dialogUI.displayDialog ("", this.currentText);
			advanceStory ();
		}
		if (state == TwineStoryState.Playing) {
			Clear ();

			// TODO: Clear output date from previous state
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

	public void SetupAndBeginStory(TwineStory story) {
		this.currentStory = story;
		
		/* Register UnityTwine callback functions */
		this.currentStory.OnOutput += Story_OnOutput;
		this.currentStory.OnStateChanged += Story_OnStateChanged;

		this.currentStory.Begin();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            advanceStory();
        }

        if (dialogUI.dialogCompleted() && CleanupFunction != null)
        {
            CleanupFunction();
            CleanupFunction = null;
        }
    }
}