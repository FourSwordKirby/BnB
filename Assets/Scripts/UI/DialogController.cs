﻿using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;


public class DialogController : MonoBehaviour
{
    public DialogUI dialogUI;

    public LoveInterest loadedLoveInterest;
    private TwineStory currentStory;
    private bool atDecision;
    private bool storyCompleted;

	public bool IgnoreEmptyLines = true;

	private string currentText;

    public void advanceStory()
    {
        if (!atDecision)
        {
            Debug.Log("Advancing!");
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
		// TODO: Clear dialog output
	}

	void Story_OnStateChanged(TwineStoryState state) {
		if (state == TwineStoryState.Idle) {
			dialogUI.displayDialog ("TestName", this.currentText);
		}
		
		//Debug.Log ("Now in state " + state);
	}

	void Story_OnOutput(TwineOutput output) {
		if (output is TwineText) {
			var text = (TwineText)output;
			if (IgnoreEmptyLines && text.Text.Trim ().Length < 1)
				return;

			this.currentText += text.Text;


		}
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
}