using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UILevelSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public string sceneLevel;
    [Space(15)]

    public Image LevelImg;
    public Image Border;
    public Color BorderColorDefault;
    public Color BorderColorOver;
    public Color BorderColorHighlight;
    public string PlaySFXOnClick = "";
    public bool Selected;
    public bool isLock;

    public void CheckLock()
    {
        isLock = PlayerPrefs.GetInt(sceneLevel, isLock ? 1 : 0) == 1;

        if (isLock)
        {
            LevelImg.color = Color.grey;
        }
        else
        {
            LevelImg.color = Color.white;

        }
    }

    //on mouse enter
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isLock) return;
        Select();
    }

    //on mouse exit
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isLock) return;
        Deselect();
    }

    //on click
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isLock) return;
        OnClick();
    }

    //select
    public void Select()
    {
        if (Border && !Selected) Border.color = BorderColorOver;
    }

    //deselect
    public void Deselect()
    {
        if (Border && !Selected) Border.color = BorderColorDefault;
    }

    //On Click
    public void OnClick()
    {
        ResetAllButtons();
        Selected = true;
        if (Border) Border.color = BorderColorHighlight;

        //play sfx
        GlobalAudioPlayer.PlaySFX(PlaySFXOnClick);

        //set selected player prefab
        CharSelection Cs = GameObject.FindObjectOfType<CharSelection>();
        if (Cs) Cs.SelectLevel(sceneLevel);
    }

    //reset all button states
    public void ResetAllButtons()
    {
        UILevelSelection[] allButtons = GameObject.FindObjectsOfType<UILevelSelection>();
        foreach (UILevelSelection button in allButtons)
        {
            button.Border.color = button.BorderColorDefault;
            button.Selected = false;
        }
    }
}