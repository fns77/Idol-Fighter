using UnityEngine;
using System.Collections;

public class GDPRS : MonoBehaviour
{
    //public string Splash = "Splash";

    //[SerializeField] GameObject GDPRPopup;

    void Start()
    {
        Advertisements.Instance.SetUserConsent(true);
        Advertisements.Instance.Initialize();
        //GDPRPopup.SetActive(false);
        //	Application.LoadLevel (Splash);
        //if user consent was set, just initialize the sdk, else request user consent
        //   if (Advertisements.Instance.UserConsentWasSet()==false)
        //  {
        // Advertisements.Instance.Initialize();
        //	GDPRPopup.SetActive(true);
        //Application.LoadLevel (Splash);
        // }
        //else
        //{
        //	Advertisements.Instance.Initialize();
        //	GDPRPopup.SetActive(false);
        //	Application.LoadLevel (Splash);
    }

    /*    void OnGUI()
        {
            //get user consent
            //if consent was not set display 2 buttons to get it and a message to inform the user about what he can do
            if (!Advertisements.Instance.UserConsentWasSet())
            {
                GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Do you prefer random ads in your app or ads relevant to you? If you choose Random no personalized data will be collected. If you choose personal all data collected will be used only to serve ads relevant to you.");
                if (GUI.Button(new Rect(buttonWidth, Screen.height - 5*buttonHeight, buttonWidth, buttonHeight), "Personalized"))
                {
                    Advertisements.Instance.SetUserConsent(true);
                    Advertisements.Instance.Initialize();
                    Application.LoadLevel (Splash);
                }

                if (GUI.Button(new Rect(2*buttonWidth, Screen.height - 5* buttonHeight, buttonWidth, buttonHeight), "Random"))
                {
                    Advertisements.Instance.SetUserConsent(false);
                    Advertisements.Instance.Initialize();
                    Application.LoadLevel (Splash);
                }

            }

        }*/
    //	}	

}