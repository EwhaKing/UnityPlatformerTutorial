using System.Diagnostics;
using UnityEngine;

// 0부터 순서대로 아이템 Coin, Invincibility, HPPotion, Projectile, Star를 나타냄
// Count는 아이템의 개수
public enum ItemType { Random=-1, Coin=0, Invincibility, HPPotion, Projectile, Star, Count }

public class Constants
{
    public static readonly int MaxLevel = 10;
    public static readonly int StarCount = 3;

    public static readonly string CurrentLevel = "CURRENT_LEVEL";
    public static readonly string LevelUnlock = "LEVEL_UNLOCK_";
    public static readonly string LevelStar = "LEVEL_STAR_";
    public static readonly string Coin = "COINCOUNT";

    public static (bool, bool[]) LoadLevelData(int level)
    {
        bool isUnlock = PlayerPrefs.GetInt($"{LevelUnlock}{level}", 0) == 1 ? true : false;

        bool[] stars = new bool[StarCount];
        for (int index = 0; index < StarCount; ++index)
        {
            stars[index] = PlayerPrefs.GetInt($"{LevelStar}{level}{index}", 0) == 1 ? true : false;
        }

        return (isUnlock, stars);
    }

    public static void LevelComplete(int level, bool[] stars, int coinCount)
    {
        PlayerPrefs.SetInt(Coin, coinCount);

        if (level + 1 <= MaxLevel)
        {
            PlayerPrefs.SetInt($"{LevelUnlock}{level + 1}", 1);
        }

        for (int index = 0; index < StarCount; ++index)
        {
            PlayerPrefs.SetInt($"{LevelStar}{level}{index}", stars[index] == true ? 1 : 0);
        }
    }
}
