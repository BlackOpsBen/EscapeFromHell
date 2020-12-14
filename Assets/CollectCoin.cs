using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] int pointsEarned = 25;
    [SerializeField] Transform pointsDisplayPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerManager>())
        {
            Collect();
        }
    }

    private void Collect()
    {
        AudioManager.Instance.PlaySound("Coin");
        GameManager.Instance.GetComponent<KeepScore>().GainPoints(pointsEarned, pointsDisplayPos.position);
        gameObject.SetActive(false);
    }
}
