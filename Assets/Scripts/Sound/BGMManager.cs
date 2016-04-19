using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGMManager : MonoBehaviour {

    public List<AudioSource> BGMtracks;

    public static AudioSource currentAudioSource;
    public static AudioSource targetAudioSource;
    public static float targetVolume;

    public static float audioAdjustRate = 0.01f;

    void Start()
    {
        currentAudioSource = BGMtracks[0];
        targetAudioSource = currentAudioSource;
    }

	// Update is called once per frame
	void Update () {
        if (targetAudioSource != currentAudioSource)
        {
            currentAudioSource.volume -= audioAdjustRate;
            if(currentAudioSource.volume == 0)
            {
                currentAudioSource.gameObject.SetActive(false);
                currentAudioSource = targetAudioSource;
            }
            return;
        }

        if(currentAudioSource.volume < targetVolume)
            currentAudioSource.volume += audioAdjustRate;
	}

    public void changeAudioSource(string name, float newVolume)
    {
        AudioSource newAudio = BGMtracks.Find(x => x.name == name);

        targetAudioSource = newAudio;
        targetVolume = newVolume;

        targetAudioSource.gameObject.SetActive(true);
        targetAudioSource.volume = 0;
    }
}
