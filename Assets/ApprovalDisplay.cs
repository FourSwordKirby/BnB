using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ApprovalDisplay : MonoBehaviour {

	public LoveInterest loveInterestInfo;
	public List<Image> hearts;
	public Image giftIcon;
	static int maxHearts = 4;
	static int approvalPerHeart = 100 / maxHearts;

	// Use this for initialization
	void Start () {	
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ShowHearts(int numHearts) {
		for (int i = 0; i < maxHearts; i++) {
            if (i < numHearts)
                hearts[i].color = new Color(hearts[i].color.r, hearts[i].color.g, hearts[i].color.b, 1.0f);
            else
                hearts[i].color = new Color(hearts[i].color.r, hearts[i].color.g, hearts[i].color.b, 0.1f);
		}
		// 1 and 2 are greyed out and 3 is fully displaying

	}

	void ShowGift(int giftKey) {
		// 1 and 2 are greyed out and 3 is fully displaying
		if (giftKey == 1 || giftKey == 2)
			giftIcon.color = new Color (giftIcon.color.r, giftIcon.color.g, giftIcon.color.b, 0.1f);
		else if (giftKey >= 3)
			giftIcon.color = new Color (giftIcon.color.r, giftIcon.color.g, giftIcon.color.b, 1f);
		else
			giftIcon.color = new Color (giftIcon.color.r, giftIcon.color.g, giftIcon.color.b, 0f);

	}

	public void RefreshHeartDisplay() {
		//Debug.Log ("Refreshing hearts for " + loveInterestInfo.designation);
		int approval = loveInterestInfo.approvalRaiting;

		int numHearts;
		if (approval <= 0)
			numHearts = 0;
		else
			numHearts = ((approval - 1) / approvalPerHeart) + 1;

		ShowHearts (numHearts);
		ShowGift (loveInterestInfo.giftStatus);

		// TODO: Logic for determining how many hearts to show
	}
}
