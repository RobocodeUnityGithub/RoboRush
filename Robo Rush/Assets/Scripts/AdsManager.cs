using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = true;
    [SerializeField] private int addCoinAd;
    private Bank bank;
    public static AdsManager Instance;


#if UNITY_ANDROID
    private string gameId = "5118363";
#elif UNITY_IOS
     private string gameId = "5118362";
#endif

    private void Awake()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    public int GetAddCoinAd()
    {
        return addCoinAd;
    }

    public void ShowAd(Bank bank)
    {
        this.bank = bank;
        Advertisement.Show("RewardedVideo");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad Ready");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                bank.AddCoin(addCoinAd);
                break;
            case ShowResult.Skipped:
                bank.AddCoin(addCoinAd);
                break;
            case ShowResult.Failed:
                Debug.Log(showResult.ToString());
                break;
        }
    }

}
