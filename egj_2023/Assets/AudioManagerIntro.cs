using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerIntro : MonoBehaviour
{
    public AudioSource MainMusic;

    private void Start()
    {
        MainMusic.Play();
    }
}
