using UnityEngine;
using System.Collections;
using UnityTwine;

public class ScriptedTutorial : MonoBehaviour {

	public DialogController dialogController;
	public GameManager gameManager;

	public Room bedroom;
	public Room parlor;


	public TwineStory tutorialA;
	public TwineStory tutorialB;

    public TwineStory wrongRoom1;
    public TwineStory wrongRoom2;


    private Room previousRoom; //Used to detect a room change
	private bool firstTimeInParlor = true;
    private int wrongRoomCount = 0;

	// Use this for initialization
	void Start () {
        Begin();
	}

	void Begin () {
		gameManager.LoadRoom (bedroom);
        previousRoom = gameManager.currentRoom;
		dialogController.StartConversation (tutorialA);

		// After Tutorial A is done, the player should go to the parlor to talk to Beau and continue the game
		// dialogController.SetupAndBeginStory(tutorialB);
	}
	
	// Update is called once per frame
	void Update () {
        if(previousRoom != gameManager.currentRoom)
        {
            if (gameManager.currentRoom == parlor)
            {
                if (firstTimeInParlor)
                {
                    firstTimeInParlor = false;
                    dialogController.StartConversation(tutorialB);

					// TODO: After tutorial done, deactivate tutorial
                }
            }
            else if (gameManager.currentRoom != bedroom) ;
            {
                if (wrongRoomCount  == 0)
                {
                    wrongRoomCount++;
                    dialogController.StartConversation(wrongRoom1);
                }
                else if (wrongRoomCount == 1)
                {
                    wrongRoomCount++;
                    dialogController.StartConversation(wrongRoom2);
                }
            }
        }
		
        previousRoom = gameManager.currentRoom;
	}
}
