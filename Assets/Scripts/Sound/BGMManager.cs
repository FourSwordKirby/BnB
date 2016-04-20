using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class BGMManager : MonoBehaviour {

    public List<AudioSource> BGMtracks;

    public int index;

    //public static AudioSource currentAudioSource;
    public static AudioSource targetAudioSource;
    public static float targetVolume = 1.0f;

    public static float audioAdjustRate = 0.01f;

    void Start()
    {
        targetAudioSource = BGMtracks[0];
        //targetAudioSource = currentAudioSource;
    }

	// Update is called once per frame
	void Update () {
        targetAudioSource = BGMtracks[index];

        if (BGMtracks.Where(x => x != targetAudioSource && x.volume > 0).Count() != 0)
        {
            foreach (AudioSource bgm in BGMtracks)
            {
                bgm.volume = Mathf.Clamp(bgm.volume - audioAdjustRate, 0.0f, 1.0f);
            }
            return;
        }

        if (targetAudioSource.volume < targetVolume)
        {
            targetAudioSource.volume += audioAdjustRate;
        }
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
