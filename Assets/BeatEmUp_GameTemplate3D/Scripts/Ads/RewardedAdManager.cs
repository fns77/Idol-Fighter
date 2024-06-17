using UnityEngine;
using UnityEngine.UI;
using Gley.MobileAds.Internal;
using Gley.MobileAds;// Pastikan untuk menggunakan namespace yang benar sesuai dengan dokumentasi plugin

public class RewardedAdManager : MonoBehaviour
{
    public GameObject targetObject; // Objek yang akan dinonaktifkan


    public void OnWatchAdButtonClicked()
    {
        if (API.IsRewardedVideoAvailable())
        {
            API.ShowRewardedVideo(CompleteMethod);
        }
        else
        {
            Debug.Log("Rewarded ad not available");
        }
    }

    private void CompleteMethod(bool completed)
    {

            if (completed == true)
            {
                targetObject.SetActive(false);
            }
            else
            {
                //targetObject.SetActive(true);
            }

#if UNITY_EDITOR
            targetObject.SetActive(false);
#endif

        
    }

}