using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelController : MonoBehaviour
{
    [Header("Fade Effect")]
    [SerializeField] private Image imageFadeScreen;

    [Header("Level UI")]
    [SerializeField] private UILevel levelPrefab;
    [SerializeField] private Transform levelParent;


    private void Awake()
    {
        StartCoroutine(FadeEffect.Fade(imageFadeScreen, 1, 0, 1, AfterFadeEffect));
        LoadLevelData();
    }

    private void AfterFadeEffect()
    {
        imageFadeScreen.gameObject.SetActive(false);
    }

    private void LoadLevelData()
    {
        PlayerPrefs.SetInt($"{Constants.LevelUnlock}1", 1);
        for (int i = 1; i <= Constants.MaxLevel; ++i)
        {
            UILevel level = Instantiate(levelPrefab, levelParent);
            (bool, bool[]) levelData = Constants.LoadLevelData(i);
            level.SetLevel(i, levelData.Item1, levelData.Item2, imageFadeScreen);
        }
    }


    [ContextMenu("ResetData")]
    //ContextMenu[(string menuName)]
    //Inspector View의 컴포넌트 위에서 마우스 오른쪽 클릭을 했을 때 menuMane 메뉴가 추가디고 해당 메뉴를 선택하면 Attributes 아래에 정의된 메소드가 호출된다.
    private void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }

}
