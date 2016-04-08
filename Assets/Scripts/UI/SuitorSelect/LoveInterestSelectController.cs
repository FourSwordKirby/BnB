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
        loveInterestIcons[(int)position].LoadLoveInterest(loveInterest, LoveInterestClicked);
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
        Debug.Log(loveInterest);
    }
}
