using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ApprovalDisplay : MonoBehaviour {

	public LoveInterest loveInterestInfo;
	public List<Image> hearts;

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
				hearts [i].gameObject.SetActive (true);
			else
				hearts [i].gameObject.SetActive (false);

		}
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

		// TODO: Logic for determining how many hearts to show
	}
}
