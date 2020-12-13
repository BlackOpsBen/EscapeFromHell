using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerManager>())
        {
            if (PlayerManager.Instance.invincible.GetIsInvincible() == false)
            {
                CardManager.Instance.GainBadCard();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerManager>())
        {
            if (PlayerManager.Instance.invincible.GetIsInvincible() == false)
            {
                CardManager.Instance.GainBadCard();
            }
        }
    }
}
