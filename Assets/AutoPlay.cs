using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlay : MonoBehaviour
{
    public bool isEnabled = false;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
