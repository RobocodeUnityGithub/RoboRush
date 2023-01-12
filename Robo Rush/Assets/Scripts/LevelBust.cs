using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBust : GameBust
{
    private void Awake()
    {
        LoadMultiplyEnemyHP();
    }

    public void AddBust()
    {
        multiplyEnemyHP++;
        SaveMultiplyEnemyHP();
    }

   private void LoadMultiplyEnemyHP()
   {
        multiplyEnemyHP = PlayerPrefs.GetInt("MultiplyEnemyHP");
   }

   private void SaveMultiplyEnemyHP()
   {
        PlayerPrefs.SetInt("MultiplyEnemyHP", multiplyEnemyHP);
   }

}
