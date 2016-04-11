﻿using UnityEngine;
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

    public TwineStory tutorialEnd;

    private static Room previousRoom; //Used to detect a room change
    public bool firstTimeInParlor;//= true;
    public int wrongRoomCount = 0;

    public bool firstTimeInGreatHall;// = true;
    public bool suitorIntroStart;// = false;
    public bool inConversation;// = false;
    public int introsCompleted;// = 0;
	public bool tutorialCompleted;// = true;

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
			if (firstTimeInParlor) {
				if (GameManager.currentRoom == parlor) {
					GameManager.StartConversation (tutorialB);

                    greatHall.inhabitants = gameManager.loveInterests.Where(x => x.designation != GameManager.LoveInterestName.Beauregard).ToList<LoveInterest>();

                    firstTimeInParlor = false;
                    firstTimeInGreatHall = true;
                } else if (GameManager.currentRoom != bedroom) {
					if (wrongRoomCount == 0) {
						wrongRoomCount++;
						GameManager.StartConversation (wrongRoom1);
					} else if (wrongRoomCount == 1) {
						wrongRoomCount++;
						GameManager.StartConversation (wrongRoom2);
					}
				}
			} else if (firstTimeInGreatHall) {
				if (GameManager.currentRoom == greatHall) {
					firstTimeInGreatHall = false;
					GameManager.StartConversation (suitorIntro);
					foreach (LoveInterest suitor in gameManager.loveInterests.Where(x => x.designation != GameManager.LoveInterestName.Beauregard)) {
						suitor.currentStory = SuitorIntros [(int)suitor.designation - 1];
					}
                    
					suitorIntroStart = true;
                    GameManager.mapControls.disableControls();
				}
			}
        }
        if (suitorIntroStart)
        {
            if (GameManager.loveInterestControls.gameObject.activeSelf == false)
            {
                inConversation = true;
            }
            if (inConversation && GameManager.loveInterestControls.gameObject.activeSelf == true)
            {
                inConversation = false;
                introsCompleted++;
            }

            if (introsCompleted > 5)
            {
                Debug.Log("ending tutorial");
                introsCompleted = int.MinValue;
                GameManager.StartConversation(tutorialEnd);
                GameManager.mapControls.enableControls();
                suitorIntroStart = false;
                tutorialCompleted = true;
            }
        }
        else if (tutorialCompleted && GameManager.loveInterestControls.gameObject.activeSelf == true)
        {
            GameManager.StartDay();
        }

        previousRoom = GameManager.currentRoom;
	}

    public void tutoiralIncrement()
    {
    }
}