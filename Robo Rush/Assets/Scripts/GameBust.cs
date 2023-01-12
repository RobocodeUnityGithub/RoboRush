using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBust : MonoBehaviour
{
    [SerializeField] protected int multiplyEnemyHP = 1;
    public UnityEvent LevelBustEvent = new UnityEvent();


    public int GetMultiplyEnemyHP()
    {
        return multiplyEnemyHP;
    }

}
