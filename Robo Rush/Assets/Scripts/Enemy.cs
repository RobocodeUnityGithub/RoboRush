using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TMP_Text healtText;
    [SerializeField] private int maxHealt;
    [SerializeField] private int currentHealt;
    private IPlayerDamage iPlayerDamage;

    private void Awake()
    {
        RecalculateHP();
        iPlayerDamage = FindObjectOfType<PlayerDamage>().GetComponent<IPlayerDamage>();
        //FindObjectOfType<LevelBusst>().LevelBusstEvent.AddListener(RecalculateHP);
    }

    private void RecalculateHP()
    {
        currentHealt = maxHealt;
        //curentHealt *= FindObjectOfType<LevelBusst>().GetMultiplyEnemyHP();
        UpdateUI();
    }

    private void UpdateUI()
    {
        healtText.text = currentHealt.ToString();
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(iPlayerDamage.GetPlayerDamage());
    }

    private void TakeDamage(int damage)
    {
        currentHealt -= damage;
        if (currentHealt <= 0)
        {
            currentHealt = 0;
            Die();
        }
        UpdateUI();
    }

    private void Die()
    {
        GetComponent<Collider>().enabled = false;
        //FindObjectOfType<LevelBusst>().LevelBusstEvent.RemoveListener(RecalculateHP);
    }
}