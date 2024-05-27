using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UILevel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Sprite spriteLevelLock;
    [SerializeField] private Image imageLevelIcon;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private GameObject startBackgroundObject;
    [SerializeField] private GameObject[] starObjects;

    private int level;
    private bool isUnlock;
    private Image imageFadeScreen;


    public void SetLevel(int level, bool isUnlock, bool[] stars, Image imageFadeScreen)
    {
        this.level = level;
        this.isUnlock = isUnlock;
        this.imageFadeScreen = imageFadeScreen;

        if (isUnlock == true)
        {
            textLevel.enabled = true;
            textLevel.text = level.ToString();
        }
        else
        {
            imageLevelIcon.sprite = spriteLevelLock;
            textLevel.enabled = false;

            startBackgroundObject.SetActive(false);
        }

        for (int i = 0; i < starObjects.Length; ++i)
        {
            starObjects[i].SetActive(stars[i]);
        }

    }

    private void AfterFadeEffect()
    {
        PlayerPrefs.SetInt(Constants.CurrentLevel, level);
        Utils.LoadScene(SceneNames.Game);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isUnlock == true)
        {
            imageFadeScreen.gameObject.SetActive(true);
            StartCoroutine(FadeEffect.Fade(imageFadeScreen, 0, 1, 1, AfterFadeEffect));
        }
    }
}
