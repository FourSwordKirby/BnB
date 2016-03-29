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

	void Story_OnStateChanged(TwineStoryState state) {
		Debug.Log ("Now in state " + state);
		
	}

	void Story_OnOutput(TwineOutput output) {
		Debug.Log (currentStory.CurrentPassageName + ":");
		Debug.Log (output.Text);
		Debug.Log (output);

		if (output is TwineText) {
			var text = (TwineText)output;
			dialogUI.displayDialog ("Test", text.Text);
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