using UnityEngine;
using System.Collections;

public class TwineParser : MonoBehaviour {

	// TODO: Eventually this script should probably not need to access the game manager
	public GameManager gameManager;

    public bool IsInstruction(string line)
    {
        return line[0] == '%';
    }

    public string TrimTag(string tag)
    {
        //Debug.Log ("Tag to be trimmed: " + tag);
        return tag.Substring(2, tag.IndexOf(">") - 2);
    }

    public GameManager.LoveInterestName ParseName(string tagName)
    {

        switch (tagName)
        {
            case "beau":
                return GameManager.LoveInterestName.Beauregard;
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
                Debug.Log("ERROR: Malformed Tag Name input: " + tagName);
                break;
        }
        return GameManager.LoveInterestName.Beauregard;
    }

    public DialogUI.ImagePositon ParsePos(string tagPos)
    {

        switch (tagPos)
        {
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
                Debug.Log("ERROR: Malformed Tag Pos input: " + tagPos);
                break;
        }
        return DialogUI.ImagePositon.Center;
    }

    public LoveInterest.Emotion ParseEmotion(string tagEmotion)
    {
        switch (tagEmotion)
        {
            case "neutral":
                return LoveInterest.Emotion.Neutral;
            case "smile":
                return LoveInterest.Emotion.Happy;
            case "blush":
                return LoveInterest.Emotion.Flattered;
            case "angry":
                return LoveInterest.Emotion.Angry;
            case "frown":
                return LoveInterest.Emotion.Angry;
            case "sad":
                return LoveInterest.Emotion.Sad;
            case "scared":
                return LoveInterest.Emotion.Scared;
            default:
                Debug.Log("ERROR: Malformed Tag Emotion input: " + tagEmotion);
                break;
        }
        return LoveInterest.Emotion.Neutral;
    }

    public bool IsReaction(string line)
    {
        return line[0] == '#';
    }

    public int ParseVariable(string varString)
    {
        /* First check that it's a general variable */
        switch (varString)
        {
            case "convo_points":
                return GameManager.dayControls.remainingConvoPts;
            case "day":
                return GameManager.dayControls.dayNumber;
            default:
                break;
        }

        /* Otherwise check that it's a love interest variable */
        string name = varString.Split('_')[0];
        string value = varString.Split('_')[1];

        if (value == "approval")
        {
            LoveInterest loveInterest = gameManager.getLoveInterest(ParseName(name));
            return loveInterest.approvalRaiting;
        }
        else if (value == "gift")
        {
            LoveInterest loveInterest = gameManager.getLoveInterest(ParseName(name));
            return loveInterest.giftStatus;
        }
        else if (value == "convo")
        {
            LoveInterest loveInterest = gameManager.getLoveInterest(ParseName(name));
            return loveInterest.convoTracker;
        }

        return 0;
    }

    public void ApplyVariable(string varString, int loveVal)
    {
        /* First check that it's a general variable */
        switch (varString)
        {
            case "convo_points":
                GameManager.dayControls.remainingConvoPts = Mathf.Clamp(loveVal, 0, 2);
                return;
            default:
                break;
        }

        /* Otherwise check that it's a love interest variable */
        string name = varString.Split('_')[0];
        string value = varString.Split('_')[1];

        if (value == "approval")
        {
            LoveInterest loveInterest = gameManager.getLoveInterest(ParseName(name));
            loveInterest.approvalRaiting = loveVal;
        }
        else if (value == "gift")
        {
            LoveInterest loveInterest = gameManager.getLoveInterest(ParseName(name));
            loveInterest.giftStatus = loveVal;
        }
        else if (value == "convo")
        {
            LoveInterest loveInterest = gameManager.getLoveInterest(ParseName(name));
            loveInterest.convoTracker = loveVal;
        }
    }

	public bool HasRestriction (string option) {
		return option [0] == '%';
	}

	public string TrimRestriction (string option) {
		return option.Substring(option.LastIndexOf("%") + 1);
	}

	public bool PassesRestriction(string option)
	{
		Debug.Log ("Checking restriction for option: " + option);
		if (option [0] == '%') {
			string restriction = option.Substring (option.IndexOf ('%') + 1, option.Substring (1).IndexOf ('%'));

			string[] restrList = restriction.Split (',');

			if (restrList.Length < 3)
				return false;

			int restrictionVar = ParseVariable (restrList [0]);
			int lowerBound = int.Parse (restrList [1]);
			int upperBound = int.Parse (restrList [2]);

			return (lowerBound <= restrictionVar && restrictionVar <= upperBound);
		} else {
			Debug.Log ("ERROR: Malformed restriction string");
			return true;
		}
	}

    public bool IsSound(string option)
    {
        return option[0] == '$';
    }

    public bool IsBGM(string option)
    {
        return option[0] == '$';
    }

    internal bool IsEnding(string option)
    {
        return option[0] == '&';
    }
}
