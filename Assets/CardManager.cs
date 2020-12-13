using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

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

    private int numBadCards = 0;

    [SerializeField] Sprite[] badCardSprites;

    [SerializeField] List<GameObject> cardObjects;

    public void GainBadCard()
    {
        PlayerManager.Instance.invincible.BecomeInvincible();

        cardObjects[numBadCards].GetComponent<UseCard>().BecomeBadCard(badCardSprites[numBadCards]);
        numBadCards++;

        if (numBadCards >= cardObjects.Count)
        {
            GameManager.Instance.GameOver();
        }

        GameManager.Instance.GetComponent<KeepScore>().IncrementMultiplier();
    }
}
