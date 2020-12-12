using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCardFunction : MonoBehaviour, ICardFunction
{
    public void UseCardFunction()
    {
        PlayerManager.Instance.Jump();
    }
}
