using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;


public class DialogController : MonoBehaviour
{
    public DialogUI dialogUI;

    public LoveInterest loadedLoveInterest;
    private TwineStory currentStory;
    private bool storyCompleted;

	public bool IgnoreEmptyLines = true;

    private List<string> lines;
    private int currentLine;
    private string currentText;
	private bool newPassage = true;

    public void advanceStory()
    {
        if (currentLine < lines.Count)
        {
            dialogUI.displayDialog("name", lines[currentLine]);
            currentLine++;


        }
        else
        {
            DisplayOptions();
        }
    }

    private void DisplayOptions()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < currentStory.Links.Count)
            {
                dialogUI.enableOption(i);
				Debug.Log ("Displaying option " + i + ": " + currentStory.Links [i].Text);
                dialogUI.displayOption(currentStory.Links[i].Text, i);
            }
            else
                dialogUI.disableOption(i);
        }
    }

	private void HideOptions()
	{
		for (int i = 0; i < 3; i++)
		{
			dialogUI.disableOption(i);
		}
	}

    public void selectOption(int option)
    {
        if (option >= currentStory.Links.Count)
        {
            Debug.Log("This option is not in range");
            return;
        }

        Debug.Log("You chose " + currentStory.Links[option].Text);

		currentStory.Advance (currentStory.Links[option]);
    }

	void Clear() {
		HideOptions ();
		// TODO: Clear dialogue box
	}

	void Story_OnStateChanged(TwineStoryState state) {
		Debug.Log ("Now in state " + state);


		if (state == TwineStoryState.Complete) {
			// TODO: What do we do when no more links?
		}
		if (state == TwineStoryState.Idle) {
			//dialogUI.displayDialog ("", this.currentText);
		}
		if (state == TwineStoryState.Playing) {
			newPassage = true;
			Clear ();

			// TODO: Clear output date from previous state
		}
		
		//Debug.Log ("Now in state " + state);
	}

	void Story_OnOutput(TwineOutput output) {
		Debug.Log ("Recieved output " + output);

		if (output is TwineText) {
			
			var text = (TwineText)output;
			if (IgnoreEmptyLines && text.Text.Trim ().Length < 1)
				return;

			lines.Add (text.Text);

			// Frojo to Roger: this is kind of ugly but works for now?
			if (newPassage) {
				newPassage = false;
				advanceStory ();
			}
		}
	}

    void Awake()
    {
        //Initializing internal variables
        this.lines = new List<string>();
        this.currentLine = 0;
    }

	void Start() {
		// TODO: This is just here for testing
        this.currentStory = loadedLoveInterest.LoveInterestStory;

		/* Register UnityTwine callback functions */
		this.currentStory.OnOutput += Story_OnOutput;
		this.currentStory.OnStateChanged += Story_OnStateChanged;

		this.currentStory.Begin();

        dialogUI.displayLoveInterest(loadedLoveInterest, LoveInterest.Emotion.Happy);
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            advanceStory();
        }
    }
}
