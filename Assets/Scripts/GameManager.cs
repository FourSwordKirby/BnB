using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

    public List<LoveInterest> loveInterests;

    public static Mansion mansion;

    public static Room currentRoom;
	public static int giftAvailable;


    public static SFXManager sfxManager;
    public static BGMManager bgmManager;
    public static DialogController dialogControls;
    public static MapController mapControls;
	public static DiaryController diaryControls;
    public static BackgroundController backgroundControls;
    public static ForegroundController foregroundControls;
    public static LoveInterestSelectController loveInterestControls;
    public static ScreenFader screenFader;
	public static DayManager dayControls;

    public static GameManager instance;

    public enum RoomName
    {
        GreatHall,
        Pasture,
        Library,
        WineCellar,
        Kitchen,
        Bedroom,
        Porch,
        Parlor,
        Dining
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

        sfxManager = GameObject.FindObjectOfType<SFXManager>();
        bgmManager = GameObject.FindObjectOfType<BGMManager>();
        dialogControls = GameObject.FindObjectOfType<DialogController>();
        mapControls = GameObject.FindObjectOfType<MapController>();
		diaryControls = GameObject.FindObjectOfType<DiaryController> ();
        backgroundControls = GameObject.FindObjectOfType<BackgroundController>();
        foregroundControls = GameObject.FindObjectOfType<ForegroundController>();
        loveInterestControls = GameObject.FindObjectOfType<LoveInterestSelectController>();
        screenFader = GameObject.FindObjectOfType<ScreenFader>();
		dayControls = GameObject.FindObjectOfType<DayManager>();

        instance = this;
    }

    public LoveInterest getLoveInterest(GameManager.LoveInterestName name)
    {
        return loveInterests[(int)name];
    }

    public static IEnumerator BeginDinner(Room room, TwineStory dinnerStory)
    {
        screenFader.setFadeTime(0.75f);
        screenFader.FadeToBlack();

        while (!screenFader.finishedFade)
            yield return new WaitForSeconds(0.1f);

        GameManager.StartConversation(dinnerStory);
        screenFader.FadeToClear();

        LoadRoom(room);

        dayControls.endOfDay = true;
    }

    public static IEnumerator MoveToRoom(Room room)
    {
        screenFader.setFadeTime(0.75f);
        screenFader.FadeToBlack();

        while(!screenFader.finishedFade)
            yield return new WaitForSeconds(0.1f);

        screenFader.FadeToClear();

        LoadRoom(room);
    }

    public static void LoadRoom(Room room)
    {
        currentRoom = room;
        backgroundControls.displayRoom(room.background);

        //used to randomly display the love interests

        List<LoveInterestSelectController.RoomPosition> positions = new List<LoveInterestSelectController.RoomPosition>
                                                                {LoveInterestSelectController.RoomPosition.FarLeft,
                                                                 LoveInterestSelectController.RoomPosition.NearLeft,
                                                                 LoveInterestSelectController.RoomPosition.Center,
                                                                 LoveInterestSelectController.RoomPosition.NearRight,
                                                                 LoveInterestSelectController.RoomPosition.FarRight};
        loveInterestControls.clearLoveInterests();

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
		diaryControls.hideControls ();
        loveInterestControls.hideLoveInterests();
    }

    public static void EndConversation()
    {
        dialogControls.CloseConversation();
        mapControls.displayControls();
		diaryControls.displayControls ();
        loveInterestControls.displayLoveInterests();

        GameManager.bgmManager.playTracks();
    }

	public static int ConvoPointsRemaining() {
		return dayControls.remainingConvoPts;
	}

	public static IEnumerable StartDay()
    {
        foregroundControls.displayScreen(dayControls.daySprites[dayControls.dayNumber - 1]);
        while (!foregroundControls.beginFadeOut)
        {
            yield return new WaitForSeconds(0.1f);
        }

        foreach (Room room in mansion.Rooms)
        {
            room.inhabitants = new List<LoveInterest>();
        }

        screenFader.FadeToClear();
		dayControls.BeginDay ();
	}


    public static GameObject titleScreen;

    public static IEnumerator EndDay()
    {
        screenFader.setFadeTime(2.0f);

        //REALLY QUICK TEMP HACK FOR THE DEMO
        //REMOVE IT ASAP
        titleScreen = GameObject.Find("TitleScreen");

        if(titleScreen != null)
        {
            foregroundControls.displayScreen(titleScreen.GetComponent<Image>().sprite);
            while (!foregroundControls.beginFadeOut)
            {
                yield return new WaitForSeconds(0.1f);
            }
            Destroy(titleScreen);
        }


        screenFader.FadeToBlack();
        while (!screenFader.finishedFade)
        {
            yield return new WaitForSeconds(0.1f);
        }

        screenFader.FadeToClear();
        foregroundControls.displayScreen(dayControls.daySprites[dayControls.dayNumber - 1]);
        while (!foregroundControls.beginFadeOut)
        {
            yield return new WaitForSeconds(0.1f);
        }

        screenFader.FadeToBlack();
        while (!screenFader.finishedFade)
        {
            yield return new WaitForSeconds(0.1f);
        }
        foregroundControls.hideScreen();


        foreach (Room room in mansion.Rooms)
        {
            room.inhabitants = new List<LoveInterest>();
        }

        dayControls.BeginDay();
        screenFader.FadeToClear();
    }
}


