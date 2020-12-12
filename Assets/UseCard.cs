using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCard : MonoBehaviour
{

    private ICardFunction cardType;

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
