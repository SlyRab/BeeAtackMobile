using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour
{
    // Start is called before the first frame update
    private const string banner = "ca-app-pub-9968615054808954/6597889711";
    private const string videoBanner = "ca-app-pub-9968615054808954/2757334163";
    private int s = 0;
    void Start()
    {
    }

    static public void ShowBanner()
    {
        BannerView bannerView = new BannerView(banner, AdSize.SmartBanner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("8411EE3F92362DFD").Build();
        bannerView.LoadAd(request);
    }

    // Update is called once per frame
    void Update()
    {
        if((Score.GetScore() % 10 == 0) && (Score.GetScore() > s))
        {
            InterstitialAd ad = new InterstitialAd(videoBanner);
            AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("8411EE3F92362DFD").Build();
            ad.LoadAd(request);
            if (ad.IsLoaded()) ad.Show();
            s = Score.GetScore();
        }
    }
}
