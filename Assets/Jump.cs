using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] Transform raySource;

    [SerializeField] float jumpMultiplier = 10f;

    private float floorTouchDist = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ExecuteJump()
    {
        AudioManager.Instance.PlaySound("Jump");

        int layerMask = 1 << LayerMask.NameToLayer("Floor");
        RaycastHit2D hit = Physics2D.Raycast(raySource.position, Vector2.down, floorTouchDist, layerMask);
        
        if (hit.collider != null)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
        }
        else
        {
            PerformDoubleJump();
        }
    }

    private void PerformDoubleJump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);

        PlayerManager.Instance.animator.SetTrigger("DoubleJump");
    }

    private void Update()
    {
        if (rb.velocity.y < 0f)
        {
            PlayerManager.Instance.animator.SetTrigger("DoubleJumpEnd");
        }
    }
}
