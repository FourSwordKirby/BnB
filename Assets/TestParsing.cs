using UnityEngine;
using System.Collections;
using UnityTwine;

public class TestParsing : MonoBehaviour {

	public DialogController dialogController;
	public GameManager gameManager;

	public Room bedroom;

	public TwineStory testScript;


	// Use this for initialization
	void Start () {
		Begin();
	}

	void Begin () {
		gameManager.LoadRoom (bedroom);

		dialogController.StartConversation (testScript);

		// After Tutorial A is done, the player should go to the parlor to talk to Beau and continue the game
		// dialogController.SetupAndBeginStory(tutorialB);
	}

	// Update is called once per frame
	void Update () {
	}
}
