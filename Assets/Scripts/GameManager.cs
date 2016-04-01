using UnityEngine;
using UnityTwine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

    public static List<LoveInterest> LoveInterests;
    public static int currentDay;
	public Room currentRoom;

    public enum Room
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
        LoveInterests = new List<LoveInterest>(GameObject.FindObjectsOfType<LoveInterest>());
    }

    public static LoveInterest getLoveInterest(GameManager.LoveInterestName name)
    {
        return LoveInterests[(int)name];
    }
}
