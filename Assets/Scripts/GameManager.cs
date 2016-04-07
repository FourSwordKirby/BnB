using UnityEngine;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

    public List<LoveInterest> loveInterests;

    public int currentDay;
    public Mansion mansion;
	public Room currentRoom;

    public DialogController dialogControls;
    public MapController mapControls;
    public BackgroundController backgroundControls;
    public LoveInterestSelectController loveInterestControls;

    public enum RoomName
    {
        Drawing,
        Parlor,
        Library,
        Kitchen,
        Dining,
        Pasture
    }

	public enum LoveInterestName
	{
		Beauregard,
		Henrietta,
		Lucille,
		John,
		Patrice,
		Noelle,
	}

    public enum Gifts
    {
        Oats,
        Letter,
        Software,
        Yarn,
        Picture
    }

    public void Awake()
    {
        //loveInterests = new List<LoveInterest>(GameObject.FindObjectsOfType<LoveInterest>());
    }

    public LoveInterest getLoveInterest(GameManager.LoveInterestName name)
    {
        return loveInterests[(int)name];
    }

    public void LoadRoom(Room room)
    {
		Debug.Log ("Loading room!");
        this.currentRoom = room;
        backgroundControls.displayRoom(room.background);
    }
}
