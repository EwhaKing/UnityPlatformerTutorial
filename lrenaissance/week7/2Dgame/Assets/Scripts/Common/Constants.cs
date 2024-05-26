using UnityEngine;
public enum ItemType
{
    Random=-1, Coin=0, Invincibility, HPPotion, Projectile, Star, Count
}

public class Constants
{
    public static readonly int MaxLevel = 10;
    public static readonly int StarCount = 3;

    public static readonly string CurrentLevel = "CURRENT_LEVEL";

    public static readonly string LevelUnlock = "LEVEL_UNLOCK_";
    public static readonly string LevelStar = "Level_STAR_";

    public static readonly string Coin = "COINCOUNT";

    public static (bool, bool[]) LoadLevelData(int level)
    {
        bool isUnlock=PlayerPrefs.GetInt($"{LevelUnlock}{level}",0)==1 ? true:false;

        bool[] stars = new bool[StarCount];

        for(int index=0; index < StarCount; ++index)
        {
            stars[index] = PlayerPrefs.GetInt($"{LevelStar}{level}{index}", 0) == 1 ? true : false;
        }

        return (isUnlock, stars);
    }

    public static void LevelComplete(int level, bool[] stars, int coinCount)//레벨 클리어시 정보 저장
    {
        PlayerPrefs.SetInt(Coin, coinCount);//코인 개수 저장

        if (level + 1 <= MaxLevel)
        {
            PlayerPrefs.SetInt($"{LevelUnlock}{level+1}",1);
        }
        for(int index=0;index<StarCount; ++index)
        {
            PlayerPrefs.SetInt($"{LevelStar}{level}{index}",stars[index]==true ? 1 : 0);
        }
    }
}