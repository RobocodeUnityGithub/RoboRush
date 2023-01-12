using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustActivator : MonoBehaviour
{
    private bool isUse;

    public void UseBust()
    {
        isUse = true;
    }

    public bool IsUse()
    {
        return isUse;
    }
}
