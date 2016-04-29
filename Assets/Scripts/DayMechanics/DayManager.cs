using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityTwine;

public class DayManager : MonoBehaviour {
	public Room bedroom;
    public Mansion mansion;
	public Room dining;

	public int remainingConvoPts;
	public int dayNumber;

    public GameManager gameManager;
    public TwineStory morningBeauStory;
    public TwineStory leavingBeauStory;
    public TwineStory leavingBeauEnd;
    public TwineStory eveningBeauStory;
    public TwineStory beauPityStory;

    public List<Sprite> daySprites;

    //Hardcoded in stories
    public TwineStory HenStory;
    public TwineStory LucyStory;
    public TwineStory JohnStory;
    public TwineStory PatStory;
    public TwineStory NoelleStory;


    //Used to keep track of if the leaving convo has been activated
    public int convoActivated;
    public bool endOfDay;

	// Use this for initialization
	void Start () {
        /*if (endOfDay)
        {
            StartCoroutine(GameManager.EndDay());
        }*/
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
        convoActivated = 0;
        endOfDay = false;

        if (GameObject.FindObjectOfType<ScriptedTutorial>() != null)
            Destroy(GameObject.FindObjectOfType<ScriptedTutorial>());

        foreach(Room room in mansion.Rooms)
            room.inhabitants = new List<LoveInterest>();

        foreach(LoveInterest suitor in gameManager.loveInterests.Where(x => x.giftStatus == 2))
            suitor.giftStatus++;

        gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).currentStory = NoelleStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).currentStory = HenStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).currentStory = PatStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.John).currentStory = JohnStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).currentStory = LucyStory;

        if (dayNumber == 1)
        {
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Library].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.John).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.WineCellar].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 2)
        {

            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.John).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Porch].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.WineCellar].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 3)
        {
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Library].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.John).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.WineCellar].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 4)
        {
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.John).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Porch].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 5)
        {
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Library].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.John).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 6)
        {
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.John).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Porch].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.WineCellar].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 7)
        {
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Library].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Porch].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).approvalRaiting > -30)
                mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 8)
        {
            //Play beau's pity story
            GameManager.StartConversation(beauPityStory);
            return;
        }

        GameManager.loveInterestControls.clearLoveInterests();

		/* Housekeeping for keeping track of info */
		remainingConvoPts = 2;
        if (dayNumber != 1)
        {
            GameManager.LoadRoom(bedroom);

            GameManager.StartConversation(morningBeauStory);
        }
	}

	void StartDinner() {
        StartCoroutine(GameManager.BeginDinner(dining, eveningBeauStory));
	}

	// Update is called once per frame
	void Update () {
        //Used to trigger leaving stories at the start of the day
        if (GameManager.dialogControls.closed && remainingConvoPts == 2)
        {
            if (gameManager.loveInterests.Where(x => x.approvalRaiting < -30 && !x.departed).ToList().Count > 0 && convoActivated == 0)
            {
                GameManager.StartConversation(leavingBeauStory);
                convoActivated = 1;
                return;
            }
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).approvalRaiting < -30
                && !gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).departed)
            {
                gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).departed = true;
                GameManager.StartConversation(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).leavingStory);
                return;
            }
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.John).approvalRaiting < -30
                && !gameManager.getLoveInterest(GameManager.LoveInterestName.John).departed)
            {
                gameManager.getLoveInterest(GameManager.LoveInterestName.John).departed = true;
                GameManager.StartConversation(gameManager.getLoveInterest(GameManager.LoveInterestName.John).leavingStory);
                return;
            }
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).approvalRaiting < -30
                && !gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).departed)
            {
                gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).departed = true;
                GameManager.StartConversation(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).leavingStory);
                return;
            }
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).approvalRaiting < -30
                && !gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).departed)
            {
                gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).departed = true;
                GameManager.StartConversation(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).leavingStory);
                return;
            }
            if (gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).approvalRaiting < -30
                && !gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).departed)
            {
                gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).departed = true;
                GameManager.StartConversation(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).leavingStory);
                return;
            }
            if (convoActivated == 1)
            {
                GameManager.StartConversation(leavingBeauEnd);
                convoActivated = 2;
                return;
            }
        }


		if (GameManager.dialogControls.dialogUI.dialogBox.dialogField.text == "" && remainingConvoPts == 0) {
            StartDinner();
            remainingConvoPts --;
		}

		if (Input.GetKeyDown("j")) {
			remainingConvoPts = 2;
		}

        if (endOfDay && GameManager.loveInterestControls.gameObject.activeSelf == true)
        {
            if (dayNumber != 0)
            {
                endOfDay = false;
                dayNumber++;
                StartCoroutine(GameManager.EndDay());
            }
            else if (Input.GetMouseButtonDown(0))
            {
                endOfDay = false;
                dayNumber++;
                StartCoroutine(GameManager.EndDay());
            }
        }
	}
}
