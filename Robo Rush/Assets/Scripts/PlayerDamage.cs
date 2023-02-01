using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface IPlayerDamage
{
    int GetPlayerDamage();
}

public class PlayerDamage : MonoBehaviour, IPlayerDamage
{
    [SerializeField] private int damage = 1;
    [SerializeField] TMP_Text damageText;

    private void Awake()
    {
        LoadDamage();
        UpdateUI();
    }

    public int GetPlayerDamage()
    {
        return damage;
    }

    public void AddDamage(int addDamage)
    {
        damage += addDamage;
        SaveDamage();
        UpdateUI();
    }

    private void LoadDamage()
    {
        if (!PlayerPrefs.HasKey("Damage"))
        {
            PlayerPrefs.SetInt("Damage", damage);
        }

        damage = PlayerPrefs.GetInt("Damage");
    }

    private void SaveDamage()
    {
        PlayerPrefs.SetInt("Damage", damage);
    }

    private void UpdateUI()
    {
        damageText.text = damage.ToString();
    }
}
