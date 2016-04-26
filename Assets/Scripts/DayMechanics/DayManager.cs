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
    public TwineStory eveningBeauStory;
    public TwineStory beauPityStory;

    public List<Sprite> daySprites;

    //Hardcoded in stories
    public TwineStory HenStory;
    public TwineStory LucyStory;
    public TwineStory JohnStory;
    public TwineStory PatStory;
    public TwineStory NoelleStory;

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
        endOfDay = false;

        if (GameObject.FindObjectOfType<ScriptedTutorial>() != null)
            Destroy(GameObject.FindObjectOfType<ScriptedTutorial>());

        foreach(Room room in mansion.Rooms)
            room.inhabitants = new List<LoveInterest>();

        foreach(LoveInterest suitor in gameManager.loveInterests.Where(x => x.giftStatus == 3))
            suitor.giftStatus++;

        gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle).currentStory = NoelleStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta).currentStory = HenStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice).currentStory = PatStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.John).currentStory = JohnStory;
        gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille).currentStory = LucyStory;

        if (dayNumber == 1)
        {
            mansion.Rooms[(int)GameManager.RoomName.Library].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            mansion.Rooms[(int)GameManager.RoomName.WineCellar].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 2)
        {
            mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            mansion.Rooms[(int)GameManager.RoomName.Porch].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            mansion.Rooms[(int)GameManager.RoomName.WineCellar].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 3)
        {
            mansion.Rooms[(int)GameManager.RoomName.Library].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            mansion.Rooms[(int)GameManager.RoomName.WineCellar].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 4)
        {
            mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            mansion.Rooms[(int)GameManager.RoomName.Porch].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 5)
        {
            mansion.Rooms[(int)GameManager.RoomName.Library].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 6)
        {
            mansion.Rooms[(int)GameManager.RoomName.Parlor].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            mansion.Rooms[(int)GameManager.RoomName.Porch].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
            mansion.Rooms[(int)GameManager.RoomName.WineCellar].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Lucille));
        }

        if (dayNumber == 7)
        {
            mansion.Rooms[(int)GameManager.RoomName.Library].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Noelle));
            mansion.Rooms[(int)GameManager.RoomName.Kitchen].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.John));
            mansion.Rooms[(int)GameManager.RoomName.Porch].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Patrice));
            mansion.Rooms[(int)GameManager.RoomName.Pasture].inhabitants.Add(gameManager.getLoveInterest(GameManager.LoveInterestName.Henrietta));
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
		if (GameManager.dialogControls.dialogUI.dialogBox.dialogField.text == "" && remainingConvoPts == 0) {
            StartDinner();
            remainingConvoPts --;
		}

        if (endOfDay && GameManager.loveInterestControls.gameObject.activeSelf == true)
        {
            endOfDay = false;
            dayNumber++;
            StartCoroutine(GameManager.EndDay());
        }
	}
}
