using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 30;

    LevelController levelController;
    Slider slider;

    void Start()
    {
        this.levelController = FindObjectOfType<LevelController>();
        this.slider = GetComponent<Slider>();
    }

    void Update()
    {
        this.slider.value = Time.timeSinceLevelLoad / this.levelTime;

        if (Time.timeSinceLevelLoad >= levelTime)
            this.levelController.FinishTimer();
    }
}
