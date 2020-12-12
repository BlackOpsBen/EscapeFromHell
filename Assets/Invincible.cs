using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    private float invincibleTime = 2f;
    private float timer = 0f;
    private float flashSpeed = 50f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool isInvincible { get; private set; }

    private void Update()
    {
        if (timer > invincibleTime)
        {
            isInvincible = false;
        }
        timer += Time.deltaTime;

        if (isInvincible)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Sin(Time.time * flashSpeed));
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public bool GetIsInvincible()
    {
        return isInvincible;
    }

    public void BecomeInvincible()
    {
        timer = 0f;
        isInvincible = true;
    }
}
