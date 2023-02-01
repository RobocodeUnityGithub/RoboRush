using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private TMP_Text currentCountManaText;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float distanceToShooting;
    [SerializeField] private float countMana;
    [SerializeField] private float countOneShootMana;
    private AudioSource audioSource;
    private ParticleSystem shootParticle;

    private Pause pause;

    private void Start()
    {
        pause =FindObjectOfType<Pause>();
        audioSource = GetComponent<AudioSource>();
        shootParticle = GetComponent<ParticleSystem>();
        UpdateUI();
    }

    public void RecalulateMana(float mana)
    {
        countMana += mana;
        if (countMana <=0)
        {
            countMana = 0;
        }
        UpdateUI();
    }

    private void Update()
    {
        if (pause.IsPause() == false)
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceToShooting, enemyLayer) && countMana > 0)
            {
                Shoot();
                countMana -= Time.deltaTime * countOneShootMana;
                UpdateUI();
            }
            else
            {
                StopShoot();
            }
        }
        else
        {
            StopShoot();
        }

    }

    private void Shoot()
    {
        shootParticle.enableEmission = true;

        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }


    private void UpdateUI() 
    {
        currentCountManaText.text = Mathf.Round(countMana).ToString();
    }

    private void StopShoot()
    {
        shootParticle.enableEmission = false;
        audioSource.Stop();
    }

    private void OnDisable()
    {
        shootParticle.Stop();
        audioSource.Stop();
    }
}