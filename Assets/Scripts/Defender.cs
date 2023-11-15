using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    [SerializeField] bool currencyGain = true;
    [Range(1, 20)] [SerializeField] int currencyAmount = 5;

    StarDisplay starDisplay;
    [SerializeField] Coin coin;

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

        for (int i = 0; i < this.currencyAmount; i++)
        {
            Coin newCoin = Instantiate(
                original: this.coin,
                position: this.transform.position,
                rotation: Quaternion.identity
            );

            newCoin.transform.localScale = new Vector3(0.035f, 0.035f, 0.035f);
            newCoin.transform.parent = transform;

            Destroy(newCoin, 2f);
        }
    }

    public int GetStarCost()
    {
        return this.starCost;
    }
}
