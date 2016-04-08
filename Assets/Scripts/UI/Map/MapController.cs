using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
    public Mansion mansion;
    public List<RoomDisplay> roomDisplays;

    public AudioClip doorClose;
    public AudioClip bigDoorClose;
    public AudioClip footsteps;

    public Image mapDisplay;

    public void displayMap()
    {
        mapDisplay.gameObject.SetActive(true);
    }
    public void hideMap()
    {
        mapDisplay.gameObject.SetActive(false);
    }

    public void displayControls()
    {
        this.gameObject.SetActive(true);
    }
    public void hideControls()
    {
        this.gameObject.SetActive(false);
    }

	public void RoomClicked(Room room) {
        Debug.Log(room);
		if (room.unlocked) {
			GameManager.LoadRoom (room);
			hideMap();
		} else {
			// TODO: Some feedback to player telling them you can't do this
		}
		// hideMap();
	}
}
