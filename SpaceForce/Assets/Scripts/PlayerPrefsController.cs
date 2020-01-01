using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const int MIN_DIFFICULTY = 0;
    const int MAX_DIFFICULTY = 2;

    const string MASTER_VOLUME_KEY = "Master Volume";
    const string DIFFICULTY_KEY = "Difficulty";

    public static float MasterVolume
    {
        get
        {
            if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY))
                return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
            else
                return 1;
        }
        set
        {
            if (MIN_VOLUME <= value && value <= MAX_VOLUME)
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
        }
    }

    public static int Difficulty
    {
        get
        {
            if (PlayerPrefs.HasKey(DIFFICULTY_KEY))
                return PlayerPrefs.GetInt(DIFFICULTY_KEY);
            else
                return 1;
        }
        set
        {
            if (MIN_DIFFICULTY <= value && value <= MAX_DIFFICULTY)
                PlayerPrefs.SetInt(DIFFICULTY_KEY, value);
        }
    }
}
