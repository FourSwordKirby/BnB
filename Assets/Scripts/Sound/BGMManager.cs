using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class BGMManager : MonoBehaviour {

    public List<AudioSource> BGMtracks;
    public int speakerIndex;
    public int mood;

    //public static AudioSource currentAudioSource;
    public static AudioSource targetAudioSource;
    public static float targetVolume = 0.5f;

    public static float audioAdjustRate = 0.005f;

    void Start()
    {
        targetAudioSource = BGMtracks[0];
        //targetAudioSource = currentAudioSource;
    }

	// Update is called once per frame
	void Update () {

        targetAudioSource = BGMtracks[(speakerIndex * 3 + 1)  + mood];

        for (int i = 0; i < BGMtracks.Count; i++)
        {
            if (i / 3 == speakerIndex && !BGMtracks[i].isPlaying)
                BGMtracks[i].Play();
            else if (i / 3 != speakerIndex && BGMtracks[i].isPlaying && BGMtracks[i].volume == 0)
                BGMtracks[i].Pause();
        }


        if (BGMtracks.Where(x => x != targetAudioSource && x.volume > 0).Count() != 0)
        {
            foreach (AudioSource bgm in BGMtracks)
            {
                bgm.volume = Mathf.Clamp(bgm.volume - audioAdjustRate, 0.0f, targetVolume);
            }
            return;
        }

        if (targetAudioSource.volume < targetVolume)
        {
            targetAudioSource.volume = Mathf.Clamp(targetAudioSource.volume + audioAdjustRate, 0.0f, targetVolume);
        }
	}

    public void changeAudioSource(string name, float newVolume)
    {
        if (targetAudioSource.name != name)
        {
            AudioSource newAudio = BGMtracks.Find(x => x.name == name);

            speakerIndex = BGMtracks.FindIndex(x => x == newAudio)/3;

            targetAudioSource = newAudio;
            targetVolume = newVolume;

            targetAudioSource.gameObject.SetActive(true);
            targetAudioSource.volume = 0;
        }
    }

    public void playTracks(GameManager.LoveInterestName loveInterestName = GameManager.LoveInterestName.Beauregard)
    {
        speakerIndex = (int)loveInterestName;
    }
}
