using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] int defaultDifficulty = 1;

    MusicPlayer musicPlayer;

    void Start()
    {
        this.volumeSlider.value = PlayerPrefsController.MasterVolume;
        this.difficultySlider.value = PlayerPrefsController.Difficulty;

        this.musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.musicPlayer)
            this.musicPlayer.SetVolume(this.volumeSlider.value);
    }

    public void ResetToDefault()
    {
        this.volumeSlider.value = this.defaultVolume;
        this.difficultySlider.value = this.defaultDifficulty;
    }

    public void Save()
    {
        PlayerPrefsController.MasterVolume = this.volumeSlider.value;
        PlayerPrefsController.Difficulty = Mathf.FloorToInt(this.difficultySlider.value);
    }
}