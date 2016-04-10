using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdvanceIcon : MonoBehaviour {
    public Image iconImage;
    public float blinkLength;
    private float blinkTime;
    private int dir;

    void Awake()
    {
        dir = -1;
    }

    void Update()
    {
        blinkTime += dir * Time.deltaTime;
        iconImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f - 0.7f * (blinkTime / blinkLength));

        if (blinkTime > blinkLength)
        {
            dir = -1;
        }
        if (blinkTime < 0)
        {
            dir = 1;
        }
    }

    public void DisplayIcon()
    {
        if (this.iconImage.enabled == false)
        {
            this.iconImage.enabled = true;
            blinkTime = blinkLength + 0.01f;
            iconImage.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        }
    }

    public void Hide()
    {
        this.iconImage.enabled = false;
    }
}
