using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject splashUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private GameObject instructionsUI;

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
        ToggleScoreScreen(false);
        ToggleGameOverScreen(false);
        ToggleInstructionsScreen(false);
    }

    public void ToggleSplashScreen(bool show)
    {
        splashUI.SetActive(show);
    }

    public void ToggleGameOverScreen(bool show)
    {
        gameOverUI.SetActive(show);
    }

    public void ToggleScoreScreen(bool show)
    {
        scoreUI.SetActive(show);
    }

    public void ToggleInstructionsScreen(bool show)
    {
        splashUI.SetActive(!show);
        instructionsUI.SetActive(show);
    }
}
