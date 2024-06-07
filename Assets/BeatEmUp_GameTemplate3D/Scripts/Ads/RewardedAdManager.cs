using UnityEngine;
using UnityEngine.UI;
using GleyMobileAds; // Pastikan untuk menggunakan namespace yang benar sesuai dengan dokumentasi plugin

public class RewardedAdManager : MonoBehaviour
{
    public GameObject targetObject; // Objek yang akan dinonaktifkan


    public void OnWatchAdButtonClicked()
    {
        //targetObject.SetActive(false);

        // Check if a rewarded ad is available
        if (Advertisements.Instance.IsRewardVideoAvailable())
        {
            // Show the rewarded ad
            Advertisements.Instance.ShowRewardedVideo(CompleteMethod);
        }
        else
        {
            Debug.Log("Rewarded ad not available");
        }
    }

    private void CompleteMethod(bool completed, string advertiser)
    {
        if (Advertisements.Instance.debug)
        {
            Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
            GleyMobileAds.ScreenWriter.Write("Closed rewarded from: " + advertiser + " -> Completed " + completed);
            targetObject.SetActive(false);
            if (completed == true)
            {
                
            }
            else
            {
                //targetObject.SetActive(true);
            }
        }
    }

}