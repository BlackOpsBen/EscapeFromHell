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

    private const int HAND_SIZE = 5;
    private int currentHandSize = 0;

    private int numBadCards = 0;

    [SerializeField] GameObject cardPrefab;

    [SerializeField] Transform cardSpawnPoint;

    [SerializeField] float spacing = 1f;
    [SerializeField] float speed = 1f;

    [SerializeField] Sprite badCardSprite;
    [SerializeField] Sprite jumpCardSprite;
    [SerializeField] Sprite shootCardSprite;
    private const int NUM_CARD_TYPES = 2; // TODO make it so I don't have to manually change this when I add a new card type.

    List<GameObject> cardObjects =  new List<GameObject>();

    void Update()
    {
        if (cardObjects.Count < currentHandSize) // Handled in Update so that it covers ALL cases where a card is needed
        {
            DrawNewCard();
        }

        ArrangeCards();
    }

    private void DrawNewCard()
    {
        GameObject drawnCard = Instantiate(cardPrefab, cardSpawnPoint.position, Quaternion.identity, gameObject.transform);
        cardObjects.Add(drawnCard);
        SetCardType(drawnCard);
    }

    private void SetCardType(GameObject drawnCard)
    {
        int rand = UnityEngine.Random.Range(0, NUM_CARD_TYPES); // TODO improve this whole thing to be dynamic and intelligent
        switch (rand)
        {
            case 0:
                drawnCard.GetComponent<UseCard>().SetCardType(drawnCard.AddComponent<JumpCardFunction>());
                drawnCard.GetComponent<SpriteRenderer>().sprite = jumpCardSprite;
                break;
            case 1:
                drawnCard.GetComponent<UseCard>().SetCardType(drawnCard.AddComponent<ShootCardFunction>());
                drawnCard.GetComponent<SpriteRenderer>().sprite = shootCardSprite;
                break;
            default:
                break;
        }
        drawnCard.GetComponent<UseCard>().SetCardType(drawnCard.AddComponent<JumpCardFunction>());
    }

    private void ArrangeCards()
    {
        for (int i = 0; i < cardObjects.Count; i++)
        {
            cardObjects[i].transform.position = Vector2.Lerp(cardObjects[i].transform.position, gameObject.transform.position + Vector3.right * spacing * i, Time.deltaTime * speed);
            cardObjects[i].name = i.ToString();
        }
    }

    public void RemoveCard(GameObject cardObject)
    {
        cardObjects.Remove(cardObject);
    }

    public void GainBadCard()
    {
        PlayerManager.Instance.invincible.BecomeInvincible();

        cardObjects[numBadCards].GetComponent<SpriteRenderer>().sprite = badCardSprite;
        Destroy(cardObjects[numBadCards].GetComponent<UseCard>());
        numBadCards++;

        if (numBadCards >= HAND_SIZE)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void DrawInitialCards()
    {
        currentHandSize = HAND_SIZE;
    }
}
