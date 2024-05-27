using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levelPrefabs; //레벨에 따라 생성되는 모든 월드 프리팹 저장
    [SerializeField]
    private StageData[] allStageData; //각 레벨별 플레이어/카메라 시작 위치 정보 저장
    [SerializeField]
    private PlayerController playerController; //stage data 정보 저장. 전달 목적
    [SerializeField]
    private CameraFollowTarget cameraController;

    [SerializeField]
    private UIGamePopup uiGamePopup; //사망,클리어 ui 호출 제어
    [SerializeField]
    private PlayerData playerData;//플레이어 별, 코인 획득 여부

    private int currentLevel = 1;//현재 레벨

    private bool isLevelFailed=false;//레벨 실패 여부
    private bool isLevelCompleted = false;//레벨 성공 여부

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt(Constants.CurrentLevel);
        playerData.Coin= PlayerPrefs.GetInt(Constants.Coin); //이전 코인 정보 저장

        GameObject level = Instantiate(levelPrefabs[currentLevel-1]); //맵 생성
        ItemStar[] starObjects=level.GetComponentsInChildren<ItemStar>();

        var levelData = Constants.LoadLevelData(currentLevel);

        for(int i = 0; i < levelData.Item2.Length; ++i)
        {
            if (levelData.Item2[i] == true)//이미 획득한 별
            {
                playerData.GetStar(i);

                for(int j = 0; j < starObjects.Length; ++j)
                {
                    if (starObjects[j].StarIndex==i)
                        starObjects[j].gameObject.SetActive(false);//획득한 별 게임에 보이지 않도록 비활성화
                }
            }
        }

        playerController.Setup(allStageData[currentLevel-1]);//stagedata 정보 넘겨주기
        cameraController.Setup(allStageData[currentLevel - 1]);
    }
    public void LevelFailed()//플레이어 사망 시 호출
    {
        if(isLevelFailed==true)//중복 방지
        {
            return;
        }
        isLevelFailed=true;
        uiGamePopup.LevelFailed();
    }

    public void LevelComplete()//레벨 클리어 시 호출
    {
        if(isLevelCompleted==true) { return; }

        isLevelCompleted = true;

        uiGamePopup.LevelComplete(playerData.Stars);
        Constants.LevelComplete(currentLevel, playerData.Stars, playerData.Coin);//다음 레벨 해금 여부, 현재 레벨 획득 별.코인 저장
    }
}
