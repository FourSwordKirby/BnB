using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;
using System;


public class DialogUI : MonoBehaviour
{
    public List<DialogOption> options;
    public DialogBox dialogBox;

    public List<Image> loveInterestImages;
    public AdvanceIcon advanceIcon;

    public enum ImagePositon
    {
        FarLeft,
        NearLeft,
        Center,
        NearRight,
        FarRight
    }

    private float displayDelay = 0.5f;

    public void Update()
    {
        if (!dialogCompleted())
        {
            displayDelay = 0.5f;
            advanceIcon.Hide();
        }
        else if (dialogBox.dialogField.text != "" && options.Find(x => x.gameObject.activeSelf == true) == null)
        {
            displayDelay -= Time.deltaTime;
            if (displayDelay < 0)
                advanceIcon.DisplayIcon();
        }
    }

    public void displayLoveInterest(LoveInterest loveInterest, LoveInterest.Emotion emotion, ImagePositon position = ImagePositon.Center)
    {
        loveInterestImages[(int)position].enabled = true;
        loveInterestImages[(int) position].sprite = loveInterest.getEmotionSprite(emotion);
    }

	public void clearLoveInterests() {

		/* The voodoo for loop guard is just the number of possible values for the
		 * enum of ImagePosition
		 */
		for (int i = 0; i < Enum.GetNames (typeof(ImagePositon)).Length; i++) {
            loveInterestImages[i].enabled = false;
		}
	}

    public void enableOption(int optionNumber)
    {
        options[optionNumber].gameObject.SetActive(true);
    }

    public void disableOption(int optionNumber)
    {
        options[optionNumber].gameObject.SetActive(false);
    }

    public void displayOption(string optionText, int optionNumber)
    {
        options[optionNumber].displayOption(optionText);
    }

    public bool dialogCompleted()
    {
        return dialogBox.dialogCompleted;
    }

    public void displayNormal()
    {
        dialogBox.dialogField.fontStyle = FontStyle.Normal;
    }

    public void displayDialog(string name, string text, DisplaySpeed speed = DisplaySpeed.fast)
    {
        dialogBox.displayDialog(name, text, speed);
    }

    public void resolveDialog()
    {
        dialogBox.resolveDialog();
    }

    public void clearDialogBox()
    {
        dialogBox.displayDialog("", "");
        advanceIcon.Hide();
    }

	public void closeDialogBox() {
		dialogBox.closeDialog ();
        advanceIcon.Hide();
	}
}