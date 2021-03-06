﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] public GameObject childForPositioning;

    public void SetText(string text, Color color)
    {
        popupText.SetText(text);
        popupText.color = color;
    }
}
