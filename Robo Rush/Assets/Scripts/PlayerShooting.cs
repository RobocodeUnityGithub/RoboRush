using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private TMP_Text currentCountManaText;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float distanceToShooting;
    [SerializeField] private float сountMana;
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
        сountMana += mana;
        if (сountMana <= 0)
        {
            сountMana = 0;
        }
        UpdateUI();
    }

    private void Update()
    {
        if (pause.IsPause() == false)
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceToShooting, enemyLayer))
            {
                Shoot();
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
        if(сountMana >0)
        {
            shootParticle.enableEmission = true;
            сountMana -= Time.deltaTime * countOneShootMana;
            UpdateUI();
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
    }


    private void UpdateUI() 
    {
        currentCountManaText.text = Mathf.Round(сountMana).ToString();
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