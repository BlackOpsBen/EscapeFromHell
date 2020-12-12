using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.transform.name + " was clicked");
            }
        }
    }
}
