using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCard : MonoBehaviour
{

    private ICardFunction cardType;

    [SerializeField] private Sprite jumpSprite;
    [SerializeField] private Sprite shootSprite;
    [SerializeField] private Sprite dashSprite;
    private int numTypes = 3; // TODO make this so I don't have to manually change if I add new types.
    private SpriteRenderer sr;

    Vector2 availablePos;
    Vector2 outPos;
    private float outPosDist = 6f;
    private float speed = 6f;

    private bool isUsed = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        availablePos = transform.position;
        outPos = new Vector2(transform.position.x, transform.position.y - outPosDist);
        ResetCard();
    }

    private void Update()
    {
        if (GameManager.Instance.state != State.SPLASH_SCREEN)
        {
            ArrangeCards();
        }
    }

    private void ArrangeCards()
    {
        transform.position = Vector2.Lerp(transform.position, availablePos, Time.deltaTime * speed);
    }

    public void Use()
    {
        if (cardType != null && isUsed == false)
        {
            isUsed = true;
            cardType.UseCardFunction();
            ResetCard();
        }
    }

    private void ResetCard()
    {
        transform.position = outPos;
        DetermineNextCardType();
        isUsed = false;
    }

    private void DetermineNextCardType()
    {
        int rand = UnityEngine.Random.Range(0, numTypes);
        switch (rand)
        {
            case 0:
                SetCardType(gameObject.AddComponent<JumpCardFunction>());
                sr.sprite = jumpSprite;
                break;
            case 1:
                SetCardType(gameObject.AddComponent<ShootCardFunction>());
                sr.sprite = shootSprite;
                break;
            case 2:
                SetCardType(gameObject.AddComponent<DashCardFunction>());
                sr.sprite = dashSprite;
                break;
            default:
                SetCardType(gameObject.AddComponent<JumpCardFunction>());
                sr.sprite = jumpSprite;
                break;
        }
    }

    private void SetCardType(ICardFunction cardFunction)
    {
        cardType = cardFunction;
    }

    public void BecomeBadCard(Sprite sprite)
    {
        cardType = null;
        sr.sprite = sprite;
    }
}
