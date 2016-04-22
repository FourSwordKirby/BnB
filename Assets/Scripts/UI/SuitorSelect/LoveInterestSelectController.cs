using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoveInterestSelectController : MonoBehaviour {
    public List<LoveInterestIcon> loveInterestIcons;

    public enum RoomPosition
    {
        FarLeft,
        NearLeft,
        Center,
        NearRight,
        FarRight
    }

    public void showLoveInterest(LoveInterest loveInterest, RoomPosition position)
    {
        loveInterestIcons[(int)position].gameObject.SetActive(true);
        loveInterestIcons[(int)position].LoadLoveInterest(loveInterest, LoveInterestClicked);
    }

    public void clearLoveInterests()
    {
        foreach(LoveInterestIcon icon in loveInterestIcons)
            icon.gameObject.SetActive(false);
    }

    public void displayLoveInterests()
    {
        this.gameObject.SetActive(true);
    }
    public void hideLoveInterests()
    {
        this.gameObject.SetActive(false);
    }

    public void LoveInterestClicked(LoveInterest loveInterest)
    {
        //We are going to want to have the game manager display the story of this love interest?
        GameManager.StartConversation(loveInterest.currentStory);
        GameManager.bgmManager.playTracks(loveInterest.designation);
    }
}
