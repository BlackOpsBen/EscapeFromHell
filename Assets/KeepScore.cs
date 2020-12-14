using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeepScore : MonoBehaviour
{
    private int scoreFromBonuses = 0;
    private int scoreFromDistance = 0;
    private int totalDistance = -3;
    private int scorePerDistanceUnit = 100;
    private int totalScore = 0;
    private int multiplier = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI distText;

    public void GainPoints(int points, Vector2 location)
    {
        int multipliedPoints = points * multiplier;
        scoreFromBonuses += multipliedPoints;
        FloatingTextManager.Instance.CreateFloatingText(multipliedPoints.ToString(), multiplier -1, location);
        UpdateScoreText();
    }

    public void GainPoints(int points)
    {
        int multipliedPoints = points * multiplier;
        scoreFromBonuses += multipliedPoints;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        totalScore = scoreFromDistance + scoreFromBonuses;
        scoreText.SetText(totalScore.ToString() + "pts");
        distText.SetText(totalDistance.ToString() + "m");
    }

    public void AddDistance()
    {
        totalDistance += 3;
        if (totalDistance > 0)
        {
            scoreFromDistance += scorePerDistanceUnit * multiplier * 3;
        }
        
        UpdateScoreText();
    }

    public void IncrementMultiplier()
    {
        multiplier++;
    }

    public int GetScore()
    {
        return totalScore;
    }

    public int GetDist()
    {
        return totalDistance;
    }
}
