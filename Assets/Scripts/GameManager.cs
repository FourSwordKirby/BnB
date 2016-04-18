using UnityEngine;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

    public List<LoveInterest> loveInterests;

    public static Mansion mansion;

    public static int currentDay;
    public static Room currentRoom;
	public static int giftAvailable;


    public static AudioManager audioManager;
    public static DialogController dialogControls;
    public static MapController mapControls;
    public static BackgroundController backgroundControls;
    public static LoveInterestSelectController loveInterestControls;
	public static DayManager dayControls;

    public enum RoomName
    {
        GreatHall,
        Pasture,
        Library,
        WineCellar,
        Kitchen,
        Bedroom,
        Porch,
        Parlor
    }

	public enum LoveInterestName
	{
		Beauregard,
		Henrietta,
		Lucille,
		John,
		Patrice,
		Noelle,
	}

    public enum Gifts
    {
        Oats,
        Letter,
        Software,
        Yarn,
        Picture
    }

    public void Awake()
    {
        //loveInterests = new List<LoveInterest>(GameObject.FindObjectsOfType<LoveInterest>());
        mansion = GameObject.FindObjectOfType<Mansion>();

        audioManager = GameObject.FindObjectOfType<AudioManager>();
        dialogControls = GameObject.FindObjectOfType<DialogController>();
        mapControls = GameObject.FindObjectOfType<MapController>();
        backgroundControls = GameObject.FindObjectOfType<BackgroundController>();
        loveInterestControls = GameObject.FindObjectOfType<LoveInterestSelectController>();
		dayControls = GameObject.FindObjectOfType<DayManager>();
    }

    public LoveInterest getLoveInterest(GameManager.LoveInterestName name)
    {
        return loveInterests[(int)name];
    }

    public static void LoadRoom(Room room)
    {
		Debug.Log ("Loading room!");
        currentRoom = room;
        backgroundControls.displayRoom(room.background);

        //used to randomly display the love interests

        List<LoveInterestSelectController.RoomPosition> positions = new List<LoveInterestSelectController.RoomPosition>
                                                                {LoveInterestSelectController.RoomPosition.FarLeft,
                                                                 LoveInterestSelectController.RoomPosition.NearLeft,
                                                                 LoveInterestSelectController.RoomPosition.Center,
                                                                 LoveInterestSelectController.RoomPosition.NearRight,
                                                                 LoveInterestSelectController.RoomPosition.FarRight};
        foreach (LoveInterest suitor in room.inhabitants)
        {
            LoveInterestSelectController.RoomPosition position = positions[Random.Range(0, positions.Count)];
            loveInterestControls.showLoveInterest(suitor, position);
            positions.Remove(position);
        }
    }
    
    //Need to put common functions that occur all the time here (like changing rooms, displaying dialog, etc.)
    public static void StartConversation(TwineStory story)
    {
        dialogControls.StartConversation(story);
        mapControls.hideControls();
        loveInterestControls.hideLoveInterests();
    }

    public static void EndConversation()
    {
        dialogControls.CloseConversation();
        mapControls.displayControls();
        loveInterestControls.displayLoveInterests();
    }

	public static int ConvoPointsRemaining() {
		return dayControls.remainingConvoPts;
	}

    public static void AdvanceDay()
    {
        currentDay++;
    }

	public static void StartDay()
	{
        foreach (Room room in mansion.Rooms)
        {
            room.inhabitants = new List<LoveInterest>();
        }

		dayControls.BeginDay ();
	}
}


