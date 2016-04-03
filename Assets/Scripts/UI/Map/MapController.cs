using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
    public Mansion mansion;
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
}
