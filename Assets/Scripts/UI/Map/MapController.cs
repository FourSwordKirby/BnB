using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
    public Mansion mansion;
	public GameManager gameManager;
    public List<RoomDisplay> roomDisplays;

	public void RoomClicked(Room room) {
		// GameManager.MoveToRoom(roomDisplay.name);
	}


}
