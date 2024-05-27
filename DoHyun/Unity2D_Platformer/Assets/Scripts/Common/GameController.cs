using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] levelPrefabs;
    [SerializeField] private StageData[] allStageData;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CameraFollowTarget cameraFollowTarget;
    [SerializeField] private UIGamePopup uiGamePopup;
    [SerializeField] private PlayerData playerData;
    private int currentLevel = 1;
    private bool isLevelFailed = false;
    private bool isLevelCompleted = false;

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt(Constants.CurrentLevel);
        playerData.Coin = PlayerPrefs.GetInt(Constants.Coin);

        GameObject level = Instantiate(levelPrefabs[currentLevel - 1]);
        ItemStar[] starObjects = level.GetComponentsInChildren<ItemStar>();
        var levelData = Constants.LoadLevelData(currentLevel);
        for (int i = 0; i < levelData.Item2.Length; ++i)
        {
            if (levelData.Item2[i] == true)
            {
                playerData.GetStar(i);
                for (int j = 0; j < starObjects.Length; ++j)
                {
                    if (starObjects[j].StarIndex == i) starObjects[j].gameObject.SetActive(false);
                }
            }

        }

        playerController.Setup(allStageData[currentLevel - 1]);
        cameraFollowTarget.Setup(allStageData[currentLevel - 1]);
    }

    public void LevelFailed()
    {
        if (isLevelFailed == true) return;
        isLevelFailed = true;
        uiGamePopup.LevelFailed();
    }

    public void LevelComplete()
    {
        if (isLevelCompleted == true) return;
        isLevelCompleted = true;
        uiGamePopup.LevelComplete(playerData.Stars);
        Constants.LevelComplete(currentLevel, playerData.Stars, playerData.Coin);
    }
}
