using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] private TMP_Text currentCoinCountText;
    private int currentCoinCount;

    private void Awake()
    {
        LoadCoinCount();
        UpdateUI();
    }

    public void AddCoin(int addCoin)
    {
        currentCoinCount += addCoin;
        UpdateUI();
        SaveCoinCount();
    }

    public bool IsCanSpend(int spendCoinCount)
    {
        if (currentCoinCount - spendCoinCount >= 0)
        {
            currentCoinCount -= spendCoinCount;
            UpdateUI();
            SaveCoinCount();
            return true;
        }

        return false;
    }


    private void UpdateUI()
    {
        currentCoinCountText.text = currentCoinCount.ToString();
    }

    private void LoadCoinCount()
    {
        currentCoinCount = PlayerPrefs.GetInt("CurrentCoinCount");
    }

    private void SaveCoinCount()
    {
        PlayerPrefs.SetInt("CurrentCoinCount", currentCoinCount);
    }
}
