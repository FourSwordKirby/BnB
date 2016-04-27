using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ForegroundController : MonoBehaviour {

    public Image foreground;

    public bool acknowledged;
    public bool beginFadeOut;


    private float waitLength = 7.0f;
    private float waitTimer;

    public void displayScreen(Sprite screenSprite)
    {
        foreground.gameObject.SetActive(true);
        foreground.sprite = screenSprite;
        beginFadeOut = false;
    }

    public void hideScreen()
    {
        foreground.gameObject.SetActive(false);
    }

    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            acknowledged = true;
        }

        if (acknowledged)
        {*/
            waitTimer += Time.deltaTime;

            if (waitTimer > waitLength)
            {
                acknowledged = false;
                beginFadeOut = true;
                waitTimer = 0.0f;
            }
        //}
    }

}
