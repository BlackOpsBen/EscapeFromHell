using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popupText;

    public void SetText(string text)
    {
        popupText.SetText(text);
    }
}
