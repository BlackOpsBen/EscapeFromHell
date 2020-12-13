﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int state;

    private bool alreadyPlayed = false;

    private float defaultScrollSpeed = 6f;
    private float scrollSpeed = 6f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        
        Instance = this;
    }

    void Start()
    {
        state = State.SPLASH_SCREEN;
        if (alreadyPlayed)
        {
            StartGame();
        }
    }

    public void GameOver()
    {
        state = State.GAME_OVER;
        UIManager.Instance.ToggleGameOverScreen(true);
        Invoke("RestartGame", 2f);
    }

    public void StartGame()
    {
        alreadyPlayed = true;
        state = State.PLAYING;
        CardManager.Instance.DrawInitialCards();
        UIManager.Instance.ToggleSplashScreen(false);
        UIManager.Instance.ToggleGameOverScreen(false);
        UIManager.Instance.ToggleScoreScreen(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    public void SetScrollSpeed(float speed)
    {
        scrollSpeed = speed;
    }

    public void ResetScrollSpeed()
    {
        scrollSpeed = defaultScrollSpeed;
    }
}

public static class State
{
    public static int SPLASH_SCREEN = 0;
    public static int PLAYING = 1;
    public static int GAME_OVER = 2;
}
