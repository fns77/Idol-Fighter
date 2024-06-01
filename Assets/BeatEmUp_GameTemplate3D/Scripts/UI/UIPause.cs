using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPause : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
       // AdmobVNTIS_Interstitial._showInterstitialImmediately();
		//AdmobVNTIS._showBanner ();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
		//AdmobVNTIS._hideBanner ();
    }
    public void Quit()
    {
        Resume();
        Application.Quit();
    }
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ProccessScene(sceneName));
    }
    IEnumerator ProccessScene(string sceneName)
    {
        Time.timeScale = 1;
        UIManager UI = GameObject.FindObjectOfType<UIManager>();
        if (UI != null)
        {
            UI.UI_fader.Fade(UIFader.FADE.FadeIn, 2f, 0);
            gameObject.SetActive(false);
            SceneManager.LoadScene(sceneName);
            yield return new WaitForSeconds(2f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
