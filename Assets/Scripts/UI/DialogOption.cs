using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DialogOption : MonoBehaviour {

    public Text optionText { get; private set; }

    void Start()
    {
        this.optionText = this.GetComponent<Text>();
    }

    public void displayOption(string option)
    {
        optionText.text = option;
    }
}