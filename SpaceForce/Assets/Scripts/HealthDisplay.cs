using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int health = 100;
    Text healthText;

    void Start()
    {
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

                FindObjectOfType<LevelLoader>().LoadYouLose();
            }

            this.UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        this.healthText.text = this.health.ToString();
    }
}
