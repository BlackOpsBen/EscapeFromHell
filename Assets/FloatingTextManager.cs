using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager Instance { get; private set; }

    [SerializeField] private GameObject popupTextPrefab;
    [SerializeField] private Transform popupParent;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void CreateFloatingText(string text, Vector2 location)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(location);
        GameObject newPopup = Instantiate(popupTextPrefab, screenPos, Quaternion.identity, popupParent);
        newPopup.GetComponent<FloatingText>().SetText(text);
    }
}
