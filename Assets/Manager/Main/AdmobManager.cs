using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;


public class AdmobManager : MonoBehaviour
{
    public bool isTestMode;

    // Start is called before the first frame update
    void Start()
    {
        LoadFrontAd();
    }
    
    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    const string frontTestID = "ca-app-pub-3940256099942544/8691691433";
    const string frontID = "ca-app-pub-7537224848353526/7169951927";
    InterstitialAd frontAd;


    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(isTestMode ? frontTestID : frontID);
        frontAd.LoadAd(GetAdRequest());
        frontAd.OnAdClosed += (sender, e) =>
        {
            SceneManager.LoadScene("Main");
        };
    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }
}
