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

	private bool firstTimeInParlor = true;

	// Use this for initialization
	void Start () {
        Begin();
	}

	void Begin () {
		gameManager.LoadRoom (bedroom);
			
		dialogController.StartConversation (tutorialA);

		// After Tutorial A is done, the player should go to the parlor to talk to Beau and continue the game
		// dialogController.SetupAndBeginStory(tutorialB);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.currentRoom == parlor) {
			Debug.Log ("In parlor!");
			if (firstTimeInParlor) {
				Debug.Log ("First time in partlor!");
				firstTimeInParlor = false;
				dialogController.StartConversation (tutorialB);
			}
		}
	}
}
