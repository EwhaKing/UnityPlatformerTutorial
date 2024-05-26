using UnityEngine;

public class UIGamePopup : MonoBehaviour
{
    [Header("공통 : 검은 배경")]
    [SerializeField]
    private GameObject overlayBackground;//팝업 배경 활성 제어

    [Header("일시정지")]
    [SerializeField]
    private GameObject popupPause;//일시정지 팝업 활성 제어

    [Header("레벨 실패")]
    [SerializeField]
    private GameObject popupLevelFailed;//레벨 실패 팝업 활성 제어

    [Header("레벨 성공")]
    [SerializeField]
    private GameObject popupLevelComplete;//레벨 성공 팝업 활성 제어
    [SerializeField]
    private GameObject[] starObjects;

    public void SetTimeScale(float scale)//시간 배속 설정
    {
        Time.timeScale = scale;
    }

    public void Pause()//일시정지
    {
        SetTimeScale(0);//배속 0
        overlayBackground.SetActive(true);
        popupPause.SetActive(true);
    }

    public void LevelFailed()//플레이어 사망 시 호출
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
        
        for(int i= 0;i< starObjects.Length; ++i) 
        {
            starObjects[i].SetActive(stars[i]);
        }
    }

    public void Resume()//재생
    {
        SetTimeScale(1);//배속 1
        overlayBackground.SetActive(false);
        popupPause.SetActive(false);
    }

    public void SelectLevel()
    {
        SetTimeScale(1);//배속 1
        Utils.LoadScene(SceneNames.SelectLevel);//level scene load
    }

    public void Restart()
    {
        SetTimeScale(1);
        Utils.LoadScene();//현재 scene load
    }

    public void NextLevel()
    {
        SetTimeScale(1);

        int currentLevel = PlayerPrefs.GetInt(Constants.CurrentLevel);
        if (currentLevel >= Constants.MaxLevel) // 현재 마지막 레벨
        {
            SelectLevel();
        }
        else
        {
            PlayerPrefs.SetInt(Constants.CurrentLevel, currentLevel+1); //레벨 +1
            Utils.LoadScene(); //현재 scene load
        }
    }
}
