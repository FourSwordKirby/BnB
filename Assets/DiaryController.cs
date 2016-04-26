using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DiaryController : MonoBehaviour {

	public Image diaryDisplay;

	public List<ApprovalDisplay> loveInterestApprovals;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RefreshAllHeartDisplays ();
	
	}

	void RefreshAllHeartDisplays() {
		foreach (ApprovalDisplay approvalDisp in loveInterestApprovals) {
			approvalDisp.RefreshHeartDisplay ();
		}
	}

	public void displayControls()
	{
		this.gameObject.SetActive(true);
	}
	public void hideControls()
	{
		this.gameObject.SetActive(false);
	}

	public void displayDiary()
	{
		diaryDisplay.gameObject.SetActive(true);
	}

	public void hideDiary()
	{
		diaryDisplay.gameObject.SetActive(false);
	}
}
