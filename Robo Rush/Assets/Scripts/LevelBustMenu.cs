using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelBustMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text levelBustText;

    private void Start()
    {
        levelBustText.text = "Level " +  FindObjectOfType<GameBust>().GetMultiplyEnemyHP().ToString();
    }
}
