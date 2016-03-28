using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {
    public List<LoveInterest> LoveInterests;

    public int currentDay;

    public enum Room
    {
        Drawing,
        Parlor,
        Library,
        Kitchen,
        Dining,
        Pasture
    }

    public enum Gifts
    {
        Oats,
        Letter,
        Software,
        Yarn,
        Picture
    }
}
