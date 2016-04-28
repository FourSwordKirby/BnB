using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SFXManager : MonoBehaviour {

    public List<AudioClip> soundEffects;

    public void play(string name)
    {
        float volume = 1.0f;

        this.GetComponent<AudioSource>().PlayOneShot(soundEffects.Find(x => x.name == name));
        //AudioSource.PlayClipAtPoint(soundEffects.Find(x => x.name == name), this.transform.position,volume);
    }
}
