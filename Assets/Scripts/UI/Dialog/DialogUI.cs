using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;


public class DialogUI : MonoBehaviour
{
    public List<DialogOption> options;
    public DialogBox dialogBox;
    public Image background;

    public List<Image> loveInterestImages;
    public enum ImagePositon
    {
        FarLeft,
        NearLeft,
        Center,
        NearRight,
        FarRight
    }

    public void displayBackground(Sprite backgroundSprite)
    {
        background.sprite = backgroundSprite;
    }

    public void displayLoveInterest(LoveInterest loveInterest, LoveInterest.Emotion emotion, ImagePositon position = ImagePositon.Center)
    {
        loveInterestImages[(int) position].sprite = loveInterest.getEmotionSprite(emotion);
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

    public void displayDialog(string name, string text, DisplaySpeed speed = DisplaySpeed.fast)
    {
        dialogBox.displayDialog(name, text, speed);
    }

    public void resolveDialog()
    {
        dialogBox.resolveDialog();
    }
}