using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] private TMP_Text addCoinText;
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private int maxCoinCost;
    [SerializeField] private int minCoinCost;
    private int coinCost;

    private void Start()
    {
        coinCost = Random.Range(minCoinCost, maxCoinCost);
        addCoinText.text = coinCost.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMover>())
        {
            FindObjectOfType<Bank>().AddCoin(coinCost);

            if (collectSound)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Destroy(gameObject);
        }
    }
}
