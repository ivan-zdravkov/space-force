using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    void Start()
    {
        this.starText = GetComponent<Text>();

        this.UpdateDisplay();
    }

    public void AddStars(int stars)
    {
        this.stars += stars;

        this.UpdateDisplay();
    }

    public void SpendStars(int stars)
    {
        if (this.stars >= stars)
        {
            this.stars -= stars;

            this.UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(int amount)
    {
        return amount <= this.stars;
    }

    private void UpdateDisplay()
    {
        this.starText.text = this.stars.ToString();
    }
}
