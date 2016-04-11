using UnityEngine;
using System.Collections;
using UnityTwine;

public class DayManager : MonoBehaviour {
	public Room bedroom;
    public Room library;
	public Room dining;

	public int remainingConvoPts;
	private int dayNumber;

    public GameManager gameManager;
	public TwineStory morningBeauStory;

    //Hardcoded in noelle story
    public TwineStory NoelleStory;

    public bool newDay;

	// Use this for initialization
	void Start () {
        if(newDay)
            BeginDay();
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

	public void BeginDay() {
        //Currently hardcoding the fact that noelle appears in a room with the appropriate story
        library.inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
        gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).currentStory = NoelleStory;


		/* Housekeeping for keeping track of info */
		remainingConvoPts = 2;
		GameManager.AdvanceDay();
		GameManager.LoadRoom (bedroom);

		// TODO: Have day-starting convo with beau
		GameManager.StartConversation (morningBeauStory);

	}

	void DinnerTime() {

		// dialogController.StartConversation(TimeForDinnerBeau);

		// gameManager.LoadRoom(bedroom);

		// dialogController.StartConversation(ChooseDinnerSuitor);

		// LoveInterest suitor = ChooseSuitor();

		// gameManager.LoadRoom (dining);

		//dialogController.StartConversation (<SuitorDinnerConvo>);


	}
	
	// Update is called once per frame
	void Update () {

		if (remainingConvoPts < 0) {
			Debug.Log ("ERROR: Remaining conversation points dipped below 0!");
		}

		if (remainingConvoPts == 0) {
			// DinnerEvent();
		}
	
	}
}
