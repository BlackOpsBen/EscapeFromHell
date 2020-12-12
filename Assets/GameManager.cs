using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int state;

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

    public float speed { get; private set; } = 2.0f;

    void Start()
    {
        state = State.SPLASH_SCREEN;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        state = State.GAME_OVER;
    }

    public void StartGame()
    {
        state = State.PLAYING;
        CardManager.Instance.DrawInitialCards();
    }
}

public static class State
{
    public static int SPLASH_SCREEN = 0;
    public static int PLAYING = 1;
    public static int GAME_OVER = 2;
}
