using UnityEngine;
using System.Collections;
using UnityTwine;

public class ScriptedTutorial : MonoBehaviour {

	public DialogController dialogController;

	public TwineStory tutorialA;
	public TwineStory tutorialB;

	// Use this for initialization
	void Start () {
        Begin();
	}

	void Begin () {
		// Set room to outside
		dialogController.SetupAndBeginStory (tutorialA);

		// After Tutorial A is done, the player should go to the parlor to talk to Beau and continue the game
		// dialogController.SetupAndBeginStory(tutorialB);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
