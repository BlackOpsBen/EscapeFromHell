using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    private List<GameObject> projectiles = new List<GameObject>();

    private const int MAX_BULLETS = 10;
    private int index = -1;

    [SerializeField] Transform muzzle;

    public void ExecuteShoot()
    {
        GetNextBullet().transform.position = muzzle.position;
    }

    private GameObject GetNextBullet()
    {
        if (projectiles.Count < MAX_BULLETS)
        {
            index++;
            GameObject newBullet = Instantiate(projectile);
            projectiles.Add(newBullet);
            return newBullet;
        }
        else
        {
            index++;
            index = index % MAX_BULLETS;
            projectiles[index].SetActive(true);
            return projectiles[index];
        }
    }
}
