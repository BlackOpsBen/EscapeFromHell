﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCardFunction : MonoBehaviour, ICardFunction
{
    public void UseCardFunction()
    {
        PlayerManager.Instance.Shoot();
    }
}
