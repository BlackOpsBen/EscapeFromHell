using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

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

    private Jump jump;

    private Shoot shoot;

    public Invincible invincible;

    private void Start()
    {
        if (!(jump = FindObjectOfType<Jump>()))
        {
            jump = gameObject.AddComponent<Jump>();
        }

        if (!(shoot = FindObjectOfType<Shoot>()))
        {
            shoot = gameObject.AddComponent<Shoot>();
        }

        if (!(invincible = FindObjectOfType<Invincible>()))
        {
            invincible = gameObject.AddComponent<Invincible>();
        }
    }

    public void Jump()
    {
        jump.ExecuteJump();
    }

    public void Shoot()
    {
        shoot.ExecuteShoot();
    }
}
