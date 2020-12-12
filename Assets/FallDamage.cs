using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    private const float FALL_THRESHOLD = -2f;
    private Vector3 startPos;
    private Rigidbody2D rb;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < FALL_THRESHOLD)
        {
            Respawn();
            if (PlayerManager.Instance.invincible.GetIsInvincible() == false)
            {
                CardManager.Instance.GainBadCard();
            }
        }
    }

    private void Respawn()
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
    }
}
