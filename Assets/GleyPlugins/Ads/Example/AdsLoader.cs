using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdsLoader : MonoBehaviour
{
    public bool IsInitialized => Advertisements.initialized;

    public static AdsLoader instance { get; private set; }

    private void Awake()
    {
        Advertisements.Instance.SetUserConsent(true);
        Advertisements.Instance.SetCCPAConsent(true);
        Init();
        DontDestroyOnLoad(gameObject);

        if(instance != null && instance != this)
        {
            Destroy(instance);
            instance = this;
        }
        else
        {
            instance = this;
        }
    }

    public void Init()
    {
        try
        {
            Advertisements.Instance.Initialize();
        }
        catch (Exception ex)
        {
            Debug.Log($"Error found: {ex}");
            throw;
        }
        

       // Advertisements.Instance.SetUserConsent(true);
    }

    public void ChangeBannerSize()
    {
        
    }

    /// <summary>
    /// Show interstitial when available
    /// </summary>
    /// <param name="OnSuccess"></param>
    /// <param name="OnFail"></param>
    public void ShowInterstitial(UnityAction OnSuccess, UnityAction OnFail)
    {
        if(IsInitialized)
        {
            OnFail?.Invoke();
        }

        if(Advertisements.Instance.IsInterstitialAvailable())
        {
            Advertisements.Instance.ShowInterstitial(OnSuccess);
        }
        else
        {
            OnFail?.Invoke();
        }
    }
}
