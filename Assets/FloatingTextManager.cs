using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager Instance { get; private set; }

    [SerializeField] private GameObject popupTextPrefab;
    [SerializeField] private Transform popupParent;

    [SerializeField] private List<Color> multiplierColors = new List<Color>();

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

    public void CreateFloatingText(string text, int currentMultiplier, Vector2 location)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(location);
        GameObject newPopup = Instantiate(popupTextPrefab, screenPos, Quaternion.identity, popupParent);
        FloatingText fl = newPopup.GetComponent<FloatingText>();
        fl.childForPositioning.transform.position = screenPos;
        fl.SetText(text, multiplierColors[currentMultiplier]);
    }
}
