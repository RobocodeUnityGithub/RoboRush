using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WathAdButton : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private  Button buttonWathAd;

    private void Start()
    {
        coinText.text = FindObjectOfType<AdsManager>().GetAddCoinAd().ToString();
        Bank bank = FindObjectOfType<Bank>();
        buttonWathAd.onClick.AddListener(bank.GetAdsMoney);
    }

}
