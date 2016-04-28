using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimeUI : MonoBehaviour {

    public Image timeDisplay;
    public List<Sprite> pointCount;

	// Update is called once per frame
	void Update () {
        timeDisplay.sprite = pointCount[Mathf.Clamp(GameManager.dayControls.remainingConvoPts, 0, 2)];
	}
}
