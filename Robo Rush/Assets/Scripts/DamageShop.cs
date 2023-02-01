using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageShop : MonoBehaviour
{
    [SerializeField] private int countAddDamage;
    [SerializeField] private TMP_Text damageCostText;
    [SerializeField] private int damageCost;
    [SerializeField] private int addDamageCost;

    private Bank bank;
    private PlayerDamage playerDamage;

    private void Start()
    {
        LoadDamageCost();
        bank = FindObjectOfType<Bank>();
        playerDamage = FindObjectOfType<PlayerDamage>();
        UpdateUI(); ;
    }

    public void BuyDamage()
    {
        if (bank.IsCanSpend(damageCost))
        {
            playerDamage.AddDamage(countAddDamage);
            damageCost += addDamageCost;
            SaveDamageCost();
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        damageCostText.text = damageCost.ToString();
    }

    private void LoadDamageCost()
    {
        if (!PlayerPrefs.HasKey("DamageCost"))
        {
            PlayerPrefs.SetInt("DamageCost", damageCost);
        }
        damageCost = PlayerPrefs.GetInt("DamageCost");
    }

    private void SaveDamageCost()
    {
        PlayerPrefs.SetInt("DamageCost", damageCost);
    }
}
