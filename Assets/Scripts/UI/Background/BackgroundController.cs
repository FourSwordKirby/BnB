using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour {

    public Image background;

    public void displayRoom(Sprite roomSprite)
    {
        background.sprite = roomSprite;
    }
}
