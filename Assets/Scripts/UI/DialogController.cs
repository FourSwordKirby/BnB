using UnityEngine;
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
        string optionText;

        switch (option)
        {
            case 1:
                optionText = "Option1";
                break;
            case 2:
                optionText = "Option2";
                break; 
            case 3:
                optionText = "Option3";
                break;
            default:
                optionText = "Error, dialog option should have been 1, 2 or 3";
                break;
        }
        
        Debug.Log("You chose " + optionText);

		//currentStory.Advance (SOMETHING);

    }

	void Clear() {
		// TODO: Clear dialog output
	}

	void Story_OnStateChanged(TwineStoryState state) {
		Debug.Log ("Now in state " + state);
		if (state == TwineStoryState.Idle) {
			dialogUI.displayDialog ("TestName", this.currentText);
		}
		
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