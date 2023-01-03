using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float distanceToShooting;
    private AudioSource audioSource;
    private ParticleSystem shootParticle;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shootParticle = GetComponent<ParticleSystem>();
    }

    private void Update()
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

    private void Shoot()
    {
        shootParticle.enableEmission = true;

        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }

    private void StopShoot()
    {
        shootParticle.enableEmission = false;
        audioSource.Stop();
    }

    private void OnDisable()
    {
        shootParticle.Stop();
    }
}