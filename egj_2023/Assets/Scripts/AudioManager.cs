using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyValuePair {
    public string key;
    public AudioSource val;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private float musicVolume = .2f;

    public AudioSource[] MainMusic;
    public List<KeyValuePair> MyList = new List<KeyValuePair>();
    private Dictionary<string, AudioSource> Sounds = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        Instance = this;
        foreach (var kvp in MyList) {
            Sounds[kvp.key] = kvp.val;
        }
    }

    public void CheckMusicIntensity(float distance)
    {
        switch (distance)
        {
            case < 4f:
                MainMusic[2].volume = musicVolume;
                break;
            case < 7f:
                MainMusic[1].volume = musicVolume;
                MainMusic[2].volume = 0;
                break;
            case < 50f:
                MainMusic[2].volume = 0;
                MainMusic[1].volume = 0;
                break;
        }
    }

    public void playMusic(int idx)
    {
        MainMusic[idx].Play();
        MainMusic[1].Play();
        MainMusic[1].volume = 0;
        MainMusic[2].Play();
        MainMusic[2].volume = 0;
    }
    
    public void playSound(string soundName)
    {
        Sounds[soundName].Play();
    }
}
