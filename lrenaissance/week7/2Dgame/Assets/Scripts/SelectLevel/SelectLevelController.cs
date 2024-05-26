using UnityEngine;
using UnityEngine.UI;

public class SelectLevelController : MonoBehaviour
{
    [Header("Fade Effect")]
    [SerializeField]
    private Image imageFadeScreen;

    [Header("Level UI")]
    [SerializeField]
    private UILevel levelPrefab;
    [SerializeField]
    private Transform levelParent;

    private void Awake()
    {
        StartCoroutine(FadeEffect.Fade(imageFadeScreen,1,0,1,AfterFadeEffect));
        LoadLevelData();//ui 출력 제어
    }

    private void AfterFadeEffect()
    {
        imageFadeScreen.gameObject.SetActive(false);
    }

    private void LoadLevelData()
    {
        PlayerPrefs.SetInt($"{Constants.LevelUnlock}1", 1); //첫번째 레벨은 항상 해금

        for(int i = 1; i <= Constants.MaxLevel; ++i)
        {
            UILevel level=Instantiate(levelPrefab,levelParent);
            (bool, bool[]) levelData = Constants.LoadLevelData(i); //lv 정보 불러오기

            level.SetLevel(i, levelData.Item1, levelData.Item2, imageFadeScreen);//Item1: 현재 lv 해금 여부, Item2: 현재 lv 별 3개 획득 여부
        }
    }

    [ContextMenu("ResetData")]
    private void ResetData()
    {
        PlayerPrefs.DeleteAll();//PlayerPrefs 초기화
    }
}
