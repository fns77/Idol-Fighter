using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GleyMobileAds;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowBanners()
    {
        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.SmartBanner);
    }

    public void HideBanners()
    {
        Advertisements.Instance.HideBanner();
    }

    public void interstitialmuncul()
    {
        Advertisements.Instance.ShowInterstitial();

    }
}
