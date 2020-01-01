using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 30;

    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        this.slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        this.slider.value = Time.timeSinceLevelLoad / this.levelTime;

        if (Time.timeSinceLevelLoad >= levelTime)
        {

        }
    }
}
