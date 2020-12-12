using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject splashUI;
    [SerializeField] private GameObject gameOverUI;

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

    private void Start()
    {
        ToggleGameOverScreen(false);
    }

    public void ToggleSplashScreen(bool show)
    {
        splashUI.SetActive(show);
    }

    public void ToggleGameOverScreen(bool show)
    {
        gameOverUI.SetActive(show);
    }
}
