using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource[] SoundAudioSoures;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void PlayOneShot(int index)
    {
        if (index < SoundAudioSoures.Length)
        {
            SoundAudioSoures[index].PlayOneShot(SoundAudioSoures[index].clip);
        }
    }
    private void PlayMusic(int index)
    {
        if (index < SoundAudioSoures.Length)
        {
            SoundAudioSoures[index].Play();
        }
    }

}
