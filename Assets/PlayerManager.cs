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

    private Dash dash;

    public Invincible invincible;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

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

        if (!(dash = FindObjectOfType<Dash>()))
        {
            dash = gameObject.AddComponent<Dash>();
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

    public void Dash()
    {
        dash.ExecuteDash();
    }
}
