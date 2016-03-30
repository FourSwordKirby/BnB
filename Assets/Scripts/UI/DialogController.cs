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

    public void advanceStory()
    {
        if (currentLine < lines.Count)
        {
            dialogUI.displayDialog("name", lines[currentLine]);
            currentLine++;
        }
        else
        {
            displayOptions();
        }
    }

    private void displayOptions()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < currentStory.Links.Count)
            {
                dialogUI.enableOption(i);
                dialogUI.displayOption(currentStory.Links[i].Text, i);
            }
            else
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
		// TODO: Clear dialog output
	}

	void Story_OnStateChanged(TwineStoryState state) {
		if (state == TwineStoryState.Idle) {
			//dialogUI.displayDialog ("", this.currentText);
		}
		
		//Debug.Log ("Now in state " + state);
	}

	void Story_OnOutput(TwineOutput output) {
		if (output is TwineText) {
			var text = (TwineText)output;
			if (IgnoreEmptyLines && text.Text.Trim ().Length < 1)
				return;

            lines.Add(text.Text);
			//this.currentText += text.Text;
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
