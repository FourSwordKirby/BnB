using UnityEngine;
using System.Collections;



public class Cheatz : MonoBehaviour {
	private string[][] cheatCodes;
	private int[] indices;
	private int NUM_CHEATS = 4;

	private const int WIN_IDX = 0;
	private const int TUT_IDX = 1;
	private const int DIN_IDX = 2;
	private const int GIFT_IDX = 3;

	public ScriptedTutorial scriptedTutorial;
	public DayManager dayManager;
	public GameManager gameManager;

	void Start() {
		// Code is "idkfa", user needs to input this in the right order
		cheatCodes = new string[NUM_CHEATS][];
		cheatCodes [WIN_IDX ] = new string[] { "w", "i", "n" };
		cheatCodes [TUT_IDX ] = new string[] { "t", "u", "t" };
		cheatCodes [DIN_IDX ] = new string[] { "d", "i", "n" };
		cheatCodes [GIFT_IDX ] = new string[] { "g", "i", "f", "t"};

		indices = new int[NUM_CHEATS];
		for (int i = 0; i < indices.Length; i++) {
			indices[i] = 0;
		}

	}

	void Update() {
		// Check if any key is pressed
		if (Input.anyKeyDown) {
			// Check if the next key in the code is pressed
			for (int i = 0; i< cheatCodes.Length; i++) {
				if (indices [i] >= cheatCodes [i].Length) {
					indices [i] = 0;
				}

				else if (Input.GetKeyDown(cheatCodes[i][indices[i]])) {
				// Add 1 to index to check the next key in the code
					indices[i]++;
				}
				// Wrong key entered, we reset code typing
				else {
					indices [i] = 0;    
				}

				// If index reaches the length of the cheatCode string, 
				// the entire code was correctly entered
				if (indices[i] == cheatCodes[i].Length) {
					switch (i) {
					case WIN_IDX:
						Debug.Log ("Unlocked win cheat!");
						foreach (LoveInterest loveInterest in gameManager.loveInterests) {
							loveInterest.approvalRaiting = 90;
						}
						break;
					case TUT_IDX:
						Debug.Log ("Unlocked tut cheat!");
						scriptedTutorial.tutorialCompleted = true;
						break;
					case DIN_IDX:
						Debug.Log ("Unlocked din cheat!");
						dayManager.remainingConvoPts = 0;
						break;
					case GIFT_IDX:
						Debug.Log ("Unlocked gift cheat!");
						foreach (LoveInterest loveInterest in gameManager.loveInterests) {
							if (loveInterest.designation == GameManager.LoveInterestName.Henrietta)
								loveInterest.giftStatus = 1;
						}
						break;
					}
				
				}
					// Cheat code successfully inputted!
					// Unlock crazy cheat code stuff

			}
		}

	}

}
