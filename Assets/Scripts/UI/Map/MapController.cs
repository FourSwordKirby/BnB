using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
    public Mansion mansion;
	public GameManager gameManager;
    public List<RoomDisplay> roomDisplays;

    public Image mapDisplay;

    public void displayMap()
    {
        mapDisplay.gameObject.SetActive(true);
    }
    public void hideMap()
    {
        mapDisplay.gameObject.SetActive(false);
    }

	public void RoomClicked(Room room) {
		if (room.unlocked) {
			gameManager.LoadRoom (room);
			hideMap();
		} else {
			// TODO: Some feedback to player telling them you can't do this
		}
		// hideMap();
	}
}
