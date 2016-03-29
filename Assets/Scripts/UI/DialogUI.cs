using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;


public class DialogUI : MonoBehaviour
{
    public List<DialogOption> options;
    public DialogBox dialogBox;

    public List<Image> loveInterestImages;
    public enum ImagePositon
    {
        FarLeft,
        NearLeft,
        Center,
        NearRight,
        Right
    }


    public void displayLoveInterest(LoveInterest loveInterest, LoveInterest.Emotion emotion, ImagePositon position = ImagePositon.Center)
    {
        loveInterestImages[(int) position].sprite = loveInterest.getEmotionSprite(emotion);
    }

    public void displayOptions(string optionText, int optionNumber)
    {
        options[optionNumber].displayOption(optionText);
    }

    public void displayDialog(string name, string text, DisplaySpeed speed = DisplaySpeed.fast)
    {
        dialogBox.displayDialog(name, text, speed);
    }
}