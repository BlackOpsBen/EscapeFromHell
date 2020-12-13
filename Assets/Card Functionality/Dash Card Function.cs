using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCardFunction : MonoBehaviour, ICardFunction
{
    public void UseCardFunction()
    {
        PlayerManager.Instance.Dash();
    }
}
