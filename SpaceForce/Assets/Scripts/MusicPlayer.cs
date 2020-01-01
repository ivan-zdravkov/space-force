using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        this.audioSource = GetComponent<AudioSource>();
        this.audioSource.volume = PlayerPrefsController.MasterVolume;
    }

    public void SetVolume(float volume)
    {
        this.audioSource.volume = volume;
    }
}
