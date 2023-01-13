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
    [SerializeField] private int damage;
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
