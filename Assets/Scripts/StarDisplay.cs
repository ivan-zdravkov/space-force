using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    int stars;
    Text starText;

    void Start()
    {
        this.SetStars();

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

    private void SetStars()
    {
        switch (PlayerPrefsController.Difficulty)
        {
            case 0:
            default:
                this.stars = 250;
                break;
            case 1:
                this.stars = 200;
                break;
            case 2:
                this.stars = 150;
                break;
        }
    }
}
