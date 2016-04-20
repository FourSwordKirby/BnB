using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoveInterestIcon: MonoBehaviour
{
    public Button UIbutton;

    public void LoadLoveInterest(LoveInterest loveInterest, System.Action<LoveInterest> LoveInterestClicked)
    {
        UIbutton.onClick.RemoveAllListeners();

        UIbutton.image.sprite = loveInterest.fullBodySprite;
        UIbutton.onClick.AddListener(() => {LoveInterestClicked(loveInterest); });
    }
}
