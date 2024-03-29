﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        this.LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();

        if (costText)
            costText.text = defenderPrefab.GetStarCost().ToString();
    }

    private void OnMouseDown()
    {
        IEnumerable<DefenderButton> buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons)
        {
            this.SetColor(button, new Color32(48, 48, 48, 255));
        }

        this.SetColor(this, Color.white);

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

    private void SetColor(DefenderButton button, Color color)
    {
        SpriteRenderer spriteRenderer = button.GetComponent<SpriteRenderer>();

        if (spriteRenderer)
            spriteRenderer.color = color;
        else
        {
            foreach (SpriteRenderer childSpriteRenderer in button.GetComponentsInChildren<SpriteRenderer>())
            {
                childSpriteRenderer.color = color;
            }
        }
    }
}
