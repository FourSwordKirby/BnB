using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityTwine;

public class ScriptedTutorial : MonoBehaviour {

    public GameManager gameManager;


	public Room bedroom;
    public Room parlor;
    public Room greatHall;


	public TwineStory tutorialA;
	public TwineStory tutorialB;

    public TwineStory wrongRoom1;
    public TwineStory wrongRoom2;

    public TwineStory suitorIntro;

    public List<TwineStory> SuitorIntros;


    private static Room previousRoom; //Used to detect a room change
	private bool firstTimeInParlor = true;
    private int wrongRoomCount = 0;

    private bool firstTimeInGreatHall = true;

	// Use this for initialization
	void Start () {
        Begin();
	}

	void Begin () {
		GameManager.LoadRoom (bedroom);
        previousRoom = GameManager.currentRoom;
		GameManager.StartConversation (tutorialA);
	}
	
	// Update is called once per frame
	void Update () {
        if(previousRoom != GameManager.currentRoom)
        {
            if (firstTimeInParlor)
            {
                if (GameManager.currentRoom == parlor)
                {
                    firstTimeInParlor = false;
                    GameManager.StartConversation(tutorialB);

                    greatHall.inhabitants = gameManager.loveInterests.Where(x => x.designation != GameManager.LoveInterestName.Beauregard).ToList<LoveInterest>();
                }
                else if (GameManager.currentRoom != bedroom)
                {
                    if (wrongRoomCount == 0)
                    {
                        wrongRoomCount++;
                        GameManager.StartConversation(wrongRoom1);
                    }
                    else if (wrongRoomCount == 1)
                    {
                        wrongRoomCount++;
                        GameManager.StartConversation(wrongRoom2);
                    }
                }
            }
            else if (firstTimeInGreatHall)
            {
                if (GameManager.currentRoom == greatHall)
                {
                    firstTimeInGreatHall = false;
                    GameManager.StartConversation(suitorIntro);
                }
            }
        }
		
        previousRoom = GameManager.currentRoom;
	}
}
