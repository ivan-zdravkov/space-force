﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        IEnumerable<DefenderButton> buttons = FindObjectsOfType<DefenderButton>();

        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(48, 48, 48, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
