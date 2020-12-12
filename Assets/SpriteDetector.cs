using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteDetector : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        addPhysics2DRaycaster();
    }

    private void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physics2DRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physics2DRaycaster == null)
        {
            gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}
