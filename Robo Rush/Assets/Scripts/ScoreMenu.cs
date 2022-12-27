using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMenu : Score
{
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        LoadScore();
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = bestScore.ToString();
    }
}