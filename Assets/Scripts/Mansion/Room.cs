using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {
    public List<LoveInterest> inhabitants;
    public Sprite background;
	public bool unlocked;
    public GameManager.RoomName roomName;
}
