using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TMP_Text healtText;
    [SerializeField] private int maxHealt;
    [SerializeField] private int countCoinsPerKill;
    [SerializeField] private int currentHealt;
    private IPlayerDamage iPlayerDamage;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        RecalculateHP();
        iPlayerDamage = FindObjectOfType<PlayerDamage>().GetComponent<IPlayerDamage>();
        //FindObjectOfType<LevelBusst>().LevelBusstEvent.AddListener(RecalculateHP);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
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
        animator.SetTrigger("Hit");
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
        animator.SetTrigger("Die");
        GetComponent<Collider>().enabled = false;
        FindObjectOfType<Bank>().AddCoin(countCoinsPerKill);
        //FindObjectOfType<LevelBusst>().LevelBusstEvent.RemoveListener(RecalculateHP);
    }
}