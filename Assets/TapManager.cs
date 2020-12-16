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

            if (hit.collider != null && hit.transform.GetComponent<UseCard>())
            {
                hit.transform.GetComponent<UseCard>().Use();
            }
        }

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                    RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

                    if (hit.collider != null && hit.transform.GetComponent<UseCard>())
                    {
                        hit.transform.GetComponent<UseCard>().Use();
                    }
                }
            }
        }
    }
        
}
