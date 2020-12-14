using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFromBullet : MonoBehaviour
{
    [SerializeField] int pointsEarned = 100;
    [SerializeField] Transform pointsDisplayPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<KillsEnemiesOnTouch>() != null)
        {
            Die();
            
            if (collision.gameObject.GetComponent<BulletMovement>() != null)
            {
                collision.gameObject.transform.position = new Vector2(100f, 100f);
                collision.gameObject.SetActive(false);
            }
        }
    }

    private void Die()
    {
        AudioManager.Instance.PlaySound("Death");
        GameManager.Instance.GetComponent<KeepScore>().GainPoints(pointsEarned, pointsDisplayPos.position);
        gameObject.SetActive(false);
    }
}
