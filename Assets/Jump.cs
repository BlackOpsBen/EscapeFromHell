using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float jumpMultiplier = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ExecuteJump()
    {
        Debug.Log("Jump Executed!"); // TODO jump behaviour
        rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
    }
}
