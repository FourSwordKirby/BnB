﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeUI : MonoBehaviour {

    public GameObject indicator;
    public List<GameObject> indicatorPositions;

	// Update is called once per frame
	void Update () {
        int desiredIndex = Mathf.Clamp(2 - GameManager.dayControls.remainingConvoPts, 0, 2);

        Vector2 desiredPosition = indicatorPositions[desiredIndex].transform.position;
        indicator.transform.position = Vector2.MoveTowards(indicator.transform.position, desiredPosition, 0.1f);
	}
}