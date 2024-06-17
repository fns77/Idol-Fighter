using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Drawing;
using Gley.MobileAds;

public class GameOverScrn : MonoBehaviour {

	public Text text;
	public Gradient ColorTransition;
	public float speed = 3.5f;
	public UIFader fader;
	private bool restartInProgress = false;

    public Button ReviveBtn;

    private void OnEnable() {
		InputManager.onCombatInputEvent += InputEvent;

        if (API.IsRewardedVideoAvailable())
        {
            ReviveBtn.interactable = true;
            //API.ShowRewardedVideo(CompleteMethod);
        }
        else
        {
            ReviveBtn.interactable = false;
        }

        // Check if a rewarded ad is available
        //if (Advertisements.Instance.IsRewardVideoAvailable())
        //{
        //	ReviveBtn.interactable = true;
        //          // Show the rewarded ad
        //          //Advertisements.Instance.ShowRewardedVideo(CompleteMethod);
        //      }
        //else
        //{
        //	ReviveBtn.interactable = false;
        //          //Debug.Log("Rewarded ad not available");
        //      }

    }

	

	private void OnDisable() {
		InputManager.onCombatInputEvent -= InputEvent;
	}

	//input event
	private void InputEvent(INPUTACTION action) {
		if (action == INPUTACTION.PUNCH || action == INPUTACTION.KICK) RestartLevel();
	}

	void Update(){

		//text effect
		if(text != null && text.gameObject.activeSelf){
			float t = Mathf.PingPong(Time.time * speed, 1f);
			text.color = ColorTransition.Evaluate(t);
		}





		//alternative input events
		//if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)){
		//	RestartLevel();
		//}
	}

    public void ShowRewardedVideo()
    {
        API.ShowRewardedVideo(CompleteMethod);
    }

    private void CompleteMethod(bool completed)
    {

            if (completed == true)
            {
                RespawnPlayer();
            }
            else
            {
                //targetObject.SetActive(true);
            }

#if UNITY_EDITOR
            RespawnPlayer();
#endif
        
    }

	public void RespawnPlayer()
	{
		GameObject player = GameObject.FindWithTag("Player");
		if (player != null)
		{
			player.GetComponent<PlayerCombat>().Respawn();
		}

        UIManager UI = GameObject.FindObjectOfType<UIManager>();

        UI.DisableAllScreens();
        
        UI.ShowMenuNoFade("HUD",false);
        UI.ShowMenuNoFade("TouchScreenControls",false);
        

    }

    //restarts the current level
    public void RestartLevel(){
		if(!restartInProgress){
			restartInProgress = true;

			//sfx
			GlobalAudioPlayer.PlaySFX("ButtonStart");

			////button flicker
			//ButtonFlicker bf =  GetComponentInChildren<ButtonFlicker>();
			//if(bf != null) bf.StartButtonFlicker();

			////fade out
			//fader.Fade(UIFader.FADE.FadeOut, 0.5f, 0.5f);

            //AdsLoader.instance.ShowInterstitial(() => 
            //{ Invoke("RestartScene", 1f); }, () => 
            //{ Invoke("RestartScene", 1f); });

            /*
			if (Advertisements.Instance.IsInterstitialAvailable())
			{
                Advertisements.Instance.ShowInterstitial(() =>
                {
                    //reload level
                    Invoke("RestartScene", 1f);
                });
            }
			else
			{
                //reload level
                Invoke("RestartScene", 1f);
            }
			*/

            Invoke("RestartScene", 1f);
        }
	}

	void RestartScene(){
		restartInProgress = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
