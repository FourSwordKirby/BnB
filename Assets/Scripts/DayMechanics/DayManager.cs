using UnityEngine;
using System.Collections;
using UnityTwine;

public class DayManager : MonoBehaviour {
	public Room bedroom;
    public Mansion mansion;
	public Room dining;

	public int remainingConvoPts;
	public int dayNumber;

    public GameManager gameManager;
	public TwineStory morningBeauStory;
    public TwineStory eveningBeauStory;

    //Hardcoded in noelle story
    public TwineStory NoelleStory;
    public TwineStory HenStory;
    public TwineStory PatStory;
    public TwineStory JohnStory;

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
        mansion.Rooms[(int)GameManager.RoomName.Library].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
        mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
        mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
        mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
        /*
        library.inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
        library.inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
        library.inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
        */
        
        gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).currentStory = NoelleStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).currentStory = HenStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).currentStory = PatStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.John).currentStory = JohnStory;


		/* Housekeeping for keeping track of info */
		remainingConvoPts = 2;
		GameManager.LoadRoom (bedroom);

		// TODO: Have day-starting convo with beau
		GameManager.StartConversation (morningBeauStory);
	}

	void StartDinner() {
        GameManager.dialogControls.StartConversation(eveningBeauStory);
		// gameManager.LoadRoom (dining);

		//dialogController.StartConversation (<SuitorDinnerConvo>);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.dialogControls.dialogUI.dialogBox.dialogField.text == "" && remainingConvoPts == 0) {
            StartDinner();
            remainingConvoPts --;
		}	
	}
}
