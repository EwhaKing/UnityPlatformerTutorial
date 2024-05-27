using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePopup : MonoBehaviour
{
    [Header("공통 : 검은 배경")]
    [SerializeField] private GameObject overlayBackground;
    [Header("일시정지")]
    [SerializeField] private GameObject popupPause;
    [Header("레벨 실패")]
    [SerializeField] private GameObject popupLevelFailed;
    [Header("레벨 성공")]
    [SerializeField] private GameObject popupLevelComplete;
    [SerializeField] private GameObject[] starObjects;

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
        //========Time.timeScale============//
        //시간이 흐르는 척도로 기본 값은 1. 이 값이 0.5면 기본 속도보다 2배 느려지고, 2면 기본 속도보다 2배 빨라진다. 또한 이 값을 0으로 설정하면 멈추게 된다.
        //Update() 메소드의 실행은 명추지 않지만, Time.deltaTime을 곱해서 사용하는 코드, 애니메이션 재생, FixedUpdate(), WaitForSeconds()가 포함된 코루틴 등이 멈춘다.
        //사운드 재생은 멈추지 않는다! 사운드는 AudioListener.pause = true;로 별도로 멈춰야 한다.
    }
    public void Pause()
    {
        SetTimeScale(0);
        overlayBackground.SetActive(true);
        popupPause.SetActive(true);
    }
    public void LevelFailed()
    {
        SetTimeScale(0);
        overlayBackground.SetActive(true);
        popupLevelFailed.SetActive(true);
    }
    public void LevelComplete(bool[] stars)
    {
        SetTimeScale(0);
        overlayBackground.SetActive(true);
        popupLevelComplete.SetActive(true);
        for (int i = 0; i < starObjects.Length; ++i)
        {
            starObjects[i].SetActive(stars[i]);
        }
    }
    public void Resume()
    {
        SetTimeScale(1);
        overlayBackground.SetActive(false);
        popupPause.SetActive(false);
    }
    public void SelectLevel()
    {
        SetTimeScale(1);
        Utils.LoadScene(SceneNames.SelectLevel);
    }
    public void Restart()
    {
        SetTimeScale(1);
        Utils.LoadScene();
    }

    public void NextLevel()
    {
        SetTimeScale(1);
        int currentLevel = PlayerPrefs.GetInt(Constants.CurrentLevel);
        if (currentLevel >= Constants.MaxLevel)
        {
            SelectLevel();
        }
        else
        {
            PlayerPrefs.SetInt(Constants.CurrentLevel, currentLevel + 1);
            Utils.LoadScene();
        }
    }
}

