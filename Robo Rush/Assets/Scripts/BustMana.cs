using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BustMana : MonoBehaviour
{
    [SerializeField] private float maxAddMana;
    [SerializeField] private float minAddMana;
    [SerializeField] private TMP_Text addManaText;
    [SerializeField] private AudioClip collectSound;
    private float currentMana;

    private void Awake()
    {
        currentMana = Random.Range(minAddMana, maxAddMana);
        addManaText.text = Mathf.Round(currentMana).ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMover>())
        {
            FindObjectOfType<PlayerShooting>().RecalulateMana(currentMana);

            if (collectSound)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Destroy(gameObject);
        }
    }
}
