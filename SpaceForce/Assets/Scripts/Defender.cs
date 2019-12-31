using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    [SerializeField] bool currencyGain = true;
    [Range(1, 20)] [SerializeField] int currencyAmount = 10;

    StarDisplay starDisplay;

    public void Start()
    {
        this.starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void Update()
    {
    }

    public void AddStars()
    {
        this.starDisplay.AddStars(this.currencyAmount);
    }
}
