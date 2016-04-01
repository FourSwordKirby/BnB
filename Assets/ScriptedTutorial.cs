using UnityEngine;
using System.Collections;
using UnityTwine;

public class ScriptedTutorial : MonoBehaviour {

	public GameManager gameManager;
	public DialogController dialogController;

	public TwineStory tutorialA;
	public TwineStory tutorialB;

	// Use this for initialization
	void Start () {	
	
	}

	void Begin () {
		// Set room to outside
		DialogController.SetupAndBeginStory (tutorialA);

		// After Tutorial A is done, change room to parlor
		DialogController.SetupAndBeginStory(tutorialB);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
