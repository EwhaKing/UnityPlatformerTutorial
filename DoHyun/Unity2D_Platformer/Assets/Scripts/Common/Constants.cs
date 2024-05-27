using UnityEngine;
public enum ItemType
{
    //임의의 아이템이 나오길 원할 때는 Random을 사용
    //0부터 순서대로 coin, invincibility, hp potion, projectile, star를 나타낸다.
    //변수 값을 0부터 순서대로 저장했기 때문에 마지막 아이템인 Star 뒤에 있는 Count의 값은 아이템 개수를 뜻한다.

    Random = -1,
    Coin = 0,
    invincibility,
    HPPotion,
    Projectile,
    Star,
    Count

}

public class Constants
{
    public static readonly int MaxLevel = 10;
    public static readonly int StarCount = 3;
    //공통으로 사용하는 문자열 정보의 경우 변수를 선언해두고 사용하면 오타를 방지할 수 있고, 수정이 용이함
    public static readonly string CurrentLevel = "CURRENT_LEVEL";
    public static readonly string LevelUnlock = "LEVEL_UNLOCK_";
    public static readonly string LevelStar = "LEVEL_START_";

    public static (bool, bool[]) LoadLevelData(int level)
    {
        bool isUnlock = PlayerPrefs.GetInt($"{LevelUnlock}{level}", 0) == 1 ? true : false;
        bool[] stars = new bool[StarCount];

        for (int index = 0; index < StarCount; ++index)
        {
            stars[index] = PlayerPrefs.GetInt($"{LevelUnlock}{level}{index}", 0) == 1 ? true : false;
        }

        return (isUnlock, stars);
    }

}