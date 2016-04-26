using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ApprovalDisplay : MonoBehaviour {

	public LoveInterest loveInterestInfo;
	public List<Image> hearts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ShowHearts(int numHearts) {


	}

	public void RefreshHeartDisplay() {
		Debug.Log ("Refreshing hearts for " + loveInterestInfo.designation);
		int approval = loveInterestInfo.approvalRaiting;

		int numHearts;
		if (approval <= 0)
			numHearts = 0;
		else
			numHearts = ((approval - 1) / 25) + 1;

		ShowHearts (numHearts);

		// TODO: Logic for determining how many hearts to show
	}
}
