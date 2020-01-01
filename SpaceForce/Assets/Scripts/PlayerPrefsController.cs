using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 1f;

    const string MASTER_VOLUME_KEY = "Master Volume";
    const string DIFFICULTY_KEY = "Difficulty";

    public static float MasterVolume
    {
        get
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        }
        set
        {
            if (MIN_VOLUME <= value && value <= MAX_VOLUME)
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
        }
    }

    public static float Difficulty
    {
        get
        {
            return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
        }
        set
        {
            if (MIN_DIFFICULTY <= value && value <= MAX_DIFFICULTY)
                PlayerPrefs.SetFloat(DIFFICULTY_KEY, value);
        }
    }
}
