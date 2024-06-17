using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gley.MobileAds;


public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            API.Initialize();
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void ShowBanners()
    {

        API.ShowBanner(BannerPosition.Bottom, BannerType.Smart);
        //Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.SmartBanner);
    }

    public void HideBanners()
    {
        API.HideBanner();
        //Advertisements.Instance.HideBanner();
    }

    public void interstitialmuncul()
    {
        API.ShowInterstitial();
        //Advertisements.Instance.ShowInterstitial();

    }
}
