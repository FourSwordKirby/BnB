using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;


public class Dialog : MonoBehaviour
{
    public List<DialogOption> options;
    public DialogBox dialogBox;
    public Image loveInterestImage;

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

    private void displayEmotion(LoveInterest.Emotion emotion)
    {
        loveInterestImage.sprite = loadedLoveInterest.getEmotionSprite(emotion);
    }

    public void selectOption(int option)
    {
        string optionText;

        switch (option)
        {
            case 1:
                optionText = options[0].optionText.text;
                break;
            case 2:
                optionText = options[0].optionText.text;
                break; 
            case 3:
                optionText = options[0].optionText.text;
                break;
            default:
                optionText = "Error, dialog option should have been 1, 2 or 3";
                break;
        }
        
        Debug.Log("You chose " + optionText);

		//currentStory.Advance (SOMETHING);

    }

	void story_OnStateChanged() {
		Debug.Log ("Now in state " + currentStory.State);
		
	}

	void story_OnOutput(TwineOutput output) {
		Debug.Log (currentStory.CurrentPassageName + ":");

	}
}