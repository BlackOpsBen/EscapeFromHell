using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCard : MonoBehaviour
{

    private ICardFunction cardType;

    void Update()  // TODO delete this
    {
        DebugUseCards();
    }

    private void DebugUseCards() // TODO delete this
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameObject.name == "0")
        {
            Use();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && gameObject.name == "1")
        {
            Use();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && gameObject.name == "2")
        {
            Use();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && gameObject.name == "3")
        {
            Use();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && gameObject.name == "4")
        {
            Use();
        }
    }

    public void Use()
    {
        if (cardType != null)
        {
            cardType.UseCardFunction();
        }
        else
        {
            Debug.LogWarning("Function was not successfully added to this object.");
        }

        CardManager.Instance.RemoveCard(gameObject);
        Destroy(gameObject);
    }

    public void SetCardType(ICardFunction cardFunction)
    {
        cardType = cardFunction;
    }
}
