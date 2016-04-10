using UnityEngine;
using UnityEngine.UI;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;
using System;


public class DialogController : MonoBehaviour
{
    public DialogUI dialogUI;
    public GameManager gameManager;

    public TwineStory currentStory;

    public AudioClip clickSound;
    
    private bool storyCompleted;

	public bool IgnoreEmptyLines = true;

    private List<string> lines;
    private int currentLine;
    private string currentText;

    public delegate void OnDisplayComplete();
    public OnDisplayComplete CleanupFunction;

    public void advanceStory()
    {
        if (!dialogUI.dialogCompleted())
        {
            dialogUI.resolveDialog();
            return;
        }

        if (currentLine < lines.Count)
        {
            string line;
            string instructions;
            do
            {
                line = "";
                instructions = "";

                line = lines[currentLine];
				                
				if (IsInstruction(line))
                {
                    instructions = line.Substring(line.IndexOf("%"), line.Substring(1).IndexOf("%")+1);
					ApplyInstructions(instructions);
                    currentLine++;
                }

                if (IsReaction(line))
                {
                    instructions = line.Substring(line.IndexOf("#") + 1, line.Substring(1).IndexOf("#"));
                    ApplyReaction(instructions);
                    currentLine++;
                }
			} while (instructions != "");

            string speakerName = "";
            string dialog = "";
			if (line.IndexOf(":") >= 0 && line.IndexOf(":") <= "BEAUREGARD".Length)
			{
                speakerName = line.Substring(0, line.IndexOf(":"));
                dialog = line.Substring(line.IndexOf(":") + 2);
            }
            else
            {
                dialog = line;
            }

            dialogUI.displayDialog(speakerName, dialog);
            currentLine++;
        }
        if (currentLine == lines.Count)
        {
			if (currentStory.State == TwineStoryState.Complete)
				storyCompleted = true;
			else
            	CleanupFunction = DisplayOptions;
        }
    }

	private string TrimTag(string tag) {
		//Debug.Log ("Tag to be trimmed: " + tag);
		return tag.Substring (2, tag.IndexOf (">") - 2);
	}
		
	private GameManager.LoveInterestName ParseName(string tagName) {

		switch (tagName) {
		case "beau":
			return GameManager.LoveInterestName.Beauregard;
			// TODO: add other cases as Sam writes them
        case "hen":
            return GameManager.LoveInterestName.Henrietta;
        case "john":
            return GameManager.LoveInterestName.John;
        case "lucy":
            return GameManager.LoveInterestName.Lucille;
        case "pat":
            return GameManager.LoveInterestName.Patrice;
        case "noelle":
            return GameManager.LoveInterestName.Noelle;
		default:
			Debug.Log ("ERROR: Malformed Tag Name input: " + tagName);
			break;
		}
		return GameManager.LoveInterestName.Beauregard;
	}

	private DialogUI.ImagePositon ParsePos(string tagPos) {

		switch (tagPos) {
		case "farleft":
			return DialogUI.ImagePositon.FarLeft;
		case "nearleft":
			return DialogUI.ImagePositon.NearLeft;
		case "center":
			return DialogUI.ImagePositon.Center;
		case "nearright":
			return DialogUI.ImagePositon.NearRight;
		case "farright":
			return DialogUI.ImagePositon.FarRight;
			// TODO: add other cases as Sam writes them
		default:
			Debug.Log ("ERROR: Malformed Tag Pos input: " + tagPos);
			break;
		}
		return DialogUI.ImagePositon.Center;
	}

	private LoveInterest.Emotion ParseEmotion(string tagEmotion) {
		switch (tagEmotion) {
		case "neutral":
			return LoveInterest.Emotion.Neutral;
		case "smile":
			return LoveInterest.Emotion.Happy;
		case "blush":
			return LoveInterest.Emotion.Flattered;
		case "angry":
			return LoveInterest.Emotion.Angry;
		case "frown":
			return LoveInterest.Emotion.Sad;
        case "scared":
            return LoveInterest.Emotion.Scared;
			// TODO: add other cases as Sam writes them
		default:
			Debug.Log ("ERROR: Malformed Tag Emotion input: " + tagEmotion);
			break;
		}
		return LoveInterest.Emotion.Neutral;
	}

    private bool IsInstruction(string line)
    {
        return line[0] == '%';
    }

	private void ApplyInstructions(string instructions) {
		string[] instrList = instructions.Split(',');

		int numCharacters;
		if (!Int32.TryParse(instrList[0].Substring(1), out numCharacters)) {
			// TODO: Handle error somehow
			Debug.Log("ERROR! Malformed input!");
		}

		//Debug.Log ("Number characters for this scene: " + numCharacters);

		dialogUI.clearLoveInterests ();

		for (int i = 0; i < numCharacters; i++) {
			GameManager.LoveInterestName name = ParseName(TrimTag(instrList [3 * i + 1]));
			DialogUI.ImagePositon position = ParsePos(TrimTag(instrList [3 * i + 2]));
			LoveInterest.Emotion emotion = ParseEmotion(TrimTag(instrList [3 * i + 3]));

            dialogUI.displayLoveInterest(gameManager.getLoveInterest(name), emotion, position);
		}
	}

    private bool IsReaction(string line)
    {
        return line[0] == '#';
    }

    private void ApplyReaction(string reaction)
    {
        string[] instrList = reaction.Split(',');


        int restrictionVar = ParseVariable(instrList[0]);
        int variableChange = int.Parse(instrList[1]);

        restrictionVar += variableChange;

        SetVariable(instrList[0], restrictionVar);
    }

    private void DisplayOptions()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < currentStory.Links.Count)
            {
                if (PassesRestriction(currentStory.Links[i].Text))
                {
                    dialogUI.enableOption(i);
                    //Debug.Log("Displaying option " + i + ": " + currentStory.Links[i].Text);
                    dialogUI.displayOption(currentStory.Links[i].Text, i);
                }
            }
            else
                dialogUI.disableOption(i);
        }
    }

    private bool PassesRestriction(string option)
    {
        if (option[0] == '%')
        {
            string restriction = option.Substring(option.IndexOf('%') + 1, option.Substring(1).IndexOf('%') - 1);

            string[] instrList = restriction.Split(',');

            int restrictionVar = ParseVariable(instrList[0]);
            int lowerApproval = int.Parse(TrimTag(instrList[1]));
            int upperApproval = int.Parse(TrimTag(instrList[2]));

            return (lowerApproval <= restrictionVar && restrictionVar <= upperApproval);
        }
        else
            return true;
    }

    private int ParseVariable(string loveVar)
    {
        string name = loveVar.Split('_')[0];
        string value = loveVar.Split('_')[1];
     
        LoveInterest loveInterest = gameManager.getLoveInterest(ParseName(name));
        if (value == "approval")
        {
            return loveInterest.approvalRaiting;
        }

        Debug.Log("AN ERROR HAPPENED OH NO");
        return 0;
    }

    private void SetVariable(string loveVar, int loveVal)
    {
        string name = loveVar.Split('_')[0];
        string value = loveVar.Split('_')[1];

        LoveInterest loveInterest = gameManager.getLoveInterest(ParseName(name));
        if (value == "approval")
        {
            loveInterest.approvalRaiting = loveVal;
            return;
        }
        else
        {
            Debug.Log("ERROR OCCURED PARSING THE STRING");
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

        //Debug.Log("You chose " + currentStory.Links[option].Text);

        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
		currentStory.Advance (currentStory.Links[option]);
    }

	public void CloseConversation() {
        //Used to ensure we don't screw up and throw an error going to a previous story
        currentStory.Reset();

		HideOptions ();
		dialogUI.clearLoveInterests ();
        dialogUI.clearDialogBox();
	}

	void Story_OnStateChanged(TwineStoryState state) {
		
		if (state == TwineStoryState.Idle || state == TwineStoryState.Complete) {
			//dialogUI.displayDialog ("", this.currentText);
			advanceStory ();
			//CleanupFunction = Close 
		} else if (state == TwineStoryState.Playing) {
            //Make sure we don't display options prematurely
            HideOptions();
		}
		
		//Debug.Log ("Now in state " + state);
	}

	void Story_OnOutput(TwineOutput output) {

		if (output is TwineText) {
			Debug.Log ("Text: " + output.Text);
			
			var text = (TwineText)output;
			if (IgnoreEmptyLines && text.Text.Trim ().Length < 1)
				return;
			lines.Add (text.Text);
		}
	}

    void Awake()
    {
        //Initializing internal variables
        this.lines = new List<string>();
    }

	public void StartConversation(TwineStory story) {

		Debug.Log ("Starting story: " + story);

		this.currentStory = story;

		storyCompleted = false;
		
		/* Register UnityTwine callback functions */
		this.currentStory.OnOutput += Story_OnOutput;
		this.currentStory.OnStateChanged += Story_OnStateChanged;

		this.currentStory.Begin();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			if (storyCompleted && dialogUI.dialogCompleted()) {
                GameManager.EndConversation();
			}
            advanceStory();
        }

        if (dialogUI.dialogCompleted() && CleanupFunction != null)
        {
            CleanupFunction();
            CleanupFunction = null;
        }
    }
}
