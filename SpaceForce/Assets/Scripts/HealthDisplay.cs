using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    int health;
    Text healthText;

    void Start()
    {
        SetHealth();

        this.healthText = GetComponent<Text>();

        this.UpdateDisplay();
    }

    public void AddHealth(int health)
    {
        this.health += health;

        this.UpdateDisplay();
    }

    public void RemoveHealth(int health)
    {
        if (this.health >= health)
        {
            this.health -= health;

            if (this.health <= 0)
            {
                this.health = 0;
            }

            this.UpdateDisplay();
        }

        if (this.health <= 0)
            FindObjectOfType<LevelController>().HandleLoseCondition();
    }

    private void UpdateDisplay()
    {
        this.healthText.text = this.health.ToString();
    }

    private void SetHealth()
    {
        switch (PlayerPrefsController.Difficulty)
        {
            case 0:
            default:
                this.health = 100;
                break;
            case 1:
                this.health = 50;
                break;
            case 2:
                this.health = 10;
                break;
        }
    }
}
