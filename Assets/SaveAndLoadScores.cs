using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SaveAndLoadScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI bestDistText;

    private int bestScore = 0;
    private int bestDist = 0;

    private void Start()
    {
        LoadBests();
    }

    private void LoadBests()
    {
        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("Dist"))
        {
            bestScore = PlayerPrefs.GetInt("Score");
            bestDist = PlayerPrefs.GetInt("Dist");
            bestScoreText.SetText("Best Score: " + bestScore.ToString() + "pts");
            bestDistText.SetText("Best Distance: " + bestDist.ToString() + "m");
        }
        else
        {
            bestScoreText.SetText("");
            bestDistText.SetText("");
        }
    }

    public void SaveBests()
    {
        int currentScore = GameManager.Instance.GetComponent<KeepScore>().GetScore();
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("Score", currentScore);
        }

        int currentDist = GameManager.Instance.GetComponent<KeepScore>().GetDist();
        if (currentDist > bestDist)
        {
            PlayerPrefs.SetInt("Dist", currentDist);
        }

        LoadBests();
    }
}
