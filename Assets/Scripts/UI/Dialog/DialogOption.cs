using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DialogOption : MonoBehaviour {

    public Text optionText;

    public void displayOption(string option)
    {
        optionText.text = option;
    }
}