using UnityEngine;
using System.Collections;

public class ApprovalDisplay : MonoBehaviour {

	public LoveInterest loveInterestInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RefreshHeartDisplay() {
		Debug.Log ("Refreshing hearts for " + loveInterestInfo.designation);
		int approval = loveInterestInfo.approvalRaiting;

		// TODO: Logic for determining how many hearts to show
	}
}
