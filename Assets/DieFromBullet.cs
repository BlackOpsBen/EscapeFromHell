using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFromBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletMovement>())
        {
            Die();
            collision.gameObject.transform.position = new Vector2(100f, 100f);
            collision.gameObject.SetActive(false);
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
