using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLeft : MonoBehaviour
{
    private float speed = 2f;
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
}
