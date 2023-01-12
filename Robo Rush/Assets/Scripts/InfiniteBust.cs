using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBust : GameBust
{
    private void AddBustLevel()
    {
        multiplyEnemyHP++;
        LevelBustEvent.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BustActivator>() != null)
        {
            BustActivator currentSpeedBustActivator = other.GetComponent<BustActivator>();

            if (currentSpeedBustActivator.IsUse() == false)
            {
                AddBustLevel();
                other.GetComponent<BustActivator>().UseBust();
            }

        }
    }
}
