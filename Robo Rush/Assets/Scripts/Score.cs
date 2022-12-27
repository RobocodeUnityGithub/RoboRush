using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    protected int bestScore;

    protected void LoadScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    protected void SaveScore()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
    }

    protected void SetNewBestScore(int newBestScore)
    {
        if (bestScore < newBestScore)
        {
            bestScore = newBestScore;
            SaveScore();
        }
    }
}

