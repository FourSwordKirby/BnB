using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoveInterestSelectController : MonoBehaviour {
    public GameManager gameManager;
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
        Debug.Log(loveInterest);
    }
}
