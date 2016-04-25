using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiaryController : MonoBehaviour {

	public Image diaryDisplay;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
