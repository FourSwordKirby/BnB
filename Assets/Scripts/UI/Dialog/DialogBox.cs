using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DialogBox : MonoBehaviour {
    public Text dialogField;
    public Text speakerField;
    public bool dialogCompleted;

    private string dialog = "";
    private int dialogTracker = 0;

    private float textDisplaySpeed;
    private float textDisplayTimer;

    private const  float FAST_DISPLAY_SPEED = 0.0f;
    private const float SLOW_DISPLAY_SPEED = 0.03f;

    // Use this for initialization
	void Awake () {
  	    this.dialogField.text = "";
        dialogCompleted = true;
	}

	// Update is called once per frame
	void Update () {
        //Do something where text appears according to the textDisplaySpeed
        if (textDisplayTimer> 0)
        {
            textDisplayTimer -= Time.deltaTime;
            return;
        }

        if (this.dialogField.text != dialog)
        {
            this.dialogField.text += dialog[dialogTracker];
            dialogTracker++;

            textDisplayTimer = textDisplaySpeed;
            dialogCompleted = false;
        }
        else
            dialogCompleted = true;
	}

    public void displayDialog(string speaker, string dialog, DisplaySpeed displaySpeed = DisplaySpeed.fast)
    {
        dialogCompleted = false;

        this.gameObject.SetActive(true);
        this.speakerField.text = speaker;
        this.dialog = dialog;
        this.dialogTracker = 0;

        //Prevents the name from flickering
        this.dialogField.text = "";

        if (displaySpeed == DisplaySpeed.immediate)
        {
            this.dialogField.text = dialog;
        }
        else if (displaySpeed == DisplaySpeed.fast)
        {
            textDisplaySpeed = FAST_DISPLAY_SPEED;
        }
        else if (displaySpeed == DisplaySpeed.slow)
        {
            textDisplaySpeed = SLOW_DISPLAY_SPEED;
        }
    }

    public void closeDialog()
    {
        this.gameObject.SetActive(false);
        //this.dialog = "";
        this.dialogTracker = 0;
    }

    public void resolveDialog()
    {
       this.dialogField.text = dialog;
    }
}

public enum DisplaySpeed{
    immediate,
    slow,
    fast
}