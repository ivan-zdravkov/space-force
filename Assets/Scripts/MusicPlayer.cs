using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip loadingSound;

    AudioSource audioSource;
    void Start()
    {
        AudioSource.PlayClipAtPoint(this.loadingSound, transform.position, PlayerPrefsController.MasterVolume);

        DontDestroyOnLoad(this);

        this.audioSource = GetComponent<AudioSource>();
        this.audioSource.volume = PlayerPrefsController.MasterVolume;
    }

    public void SetVolume(float volume)
    {
        this.audioSource.volume = volume;
    }
}
