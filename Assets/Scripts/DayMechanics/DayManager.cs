using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {

	public GameManager gameManager;
	public DialogController dialogController;

	public Room bedroom;
	public Room dining;

	private int remainingConvoPts;
	private int dayNumber;



	// Use this for initialization
	void Start () {
	
	}


	/* A Day consists of:
	 * 
	 * Wake up in the bedroom. Beauregard is there.
	 * Choose to ask him:
	 * -Suitor's opinions of you
	 * -Get favor/gift for somebody (if they've shown interest in you - high enough approval) and will show up next morning
	 * 
	 * Travel from room to room by clicking on the map
	 * When you're in the room, characters are in their "set location" in the room (if they're in the room)
	 * You can click on the characters to talk to them
	 * 
	 * Unlimited light conversations
	 * Deep conversations where you talk about the person they're talking to 
	 * 
	 * After using 2 convo points: beau appears and says it's time for dinner
	 * Choose a suitor to go to dinner with
	 * Dinner is a stressful/emotional affair
	 * 
	 * After dinner, Beau appears and you go to bed
	 * 
	 */

	void BeginDay() {

		/* Housekeeping for keeping track of info */
		remainingConvoPts = 2;
		dayNumber++;

		gameManager.LoadRoom (bedroom);

		// dialogController.StartConversation (MorningBeau);



	}

	void DinnerEvent() {

		// TODO: Choose suitor

		// S

		gameManager.LoadRoom (dining);

		//dialogController.StartConversation (Dinner);


	}
	
	// Update is called once per frame
	void Update () {

		if (remainingConvoPts < 0) {
			Debug.Log ("ERROR: Remaining conversation points dipped below 0!");
		}

		if (remainingConvoPts == 0) {
			// TODO: Dinner time!
		}
	
	}
}
