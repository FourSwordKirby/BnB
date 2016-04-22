using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
    public Mansion mansion;
    public Button activationButton;
    public List<RoomDisplay> roomDisplays;

    public AudioClip doorClose;
    public AudioClip bigDoorClose;
    public AudioClip footsteps;

    public Image mapDisplay;

    void Update()
    {
        foreach (Room room in mansion.Rooms)
        {
            for(int i = 0; i < room.inhabitants.Count;i++)
            {
                LoveInterest suitor = room.inhabitants[i];
                roomDisplays[(int)room.roomName].SuitorIcons[i].sprite = suitor.loveInterestIcon;
                roomDisplays[(int)room.roomName].SuitorIcons[i].gameObject.SetActive(true);
            }
            for (int i = room.inhabitants.Count; i < roomDisplays[(int)room.roomName].SuitorIcons.Count; i++)
            {
                roomDisplays[(int)room.roomName].SuitorIcons[i].gameObject.SetActive(false);
            }
        }
    }

    public void displayMap()
    {
        mapDisplay.gameObject.SetActive(true);
    }
    public void hideMap()
    {
        mapDisplay.gameObject.SetActive(false);
    }

    public void disableControls()
    {
        activationButton.interactable = false;
    }
    public void enableControls()
    {
        activationButton.interactable = true;
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
		if (room.unlocked) {
			StartCoroutine(GameManager.MoveToRoom (room));
			hideMap();
		} else {
			// TODO: Some feedback to player telling them you can't do this
		}
		// hideMap();
	}
}
