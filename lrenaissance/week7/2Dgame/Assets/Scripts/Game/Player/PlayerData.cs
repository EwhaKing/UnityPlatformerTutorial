using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private UIPlayerData uiPlayerData;

    private int coin = 0;

    private int projectile = 0;

    [SerializeField]
    private bool[] stars = new bool[3] { false, false, false };

    public int Coin
    {
        set {
            coin = Mathf.Clamp(value, 0, 9999);
            uiPlayerData.SetCoin(coin);
        }
        get=> coin;
    }

    public int MaxProjectile //get만 가능한 속성이라 수정 불가능
    {
        get;
    } = 10;

    public int CurrentProjectile
    {
        set {
            projectile = Mathf.Clamp(value, 0, MaxProjectile);
            uiPlayerData.SetProjectile(projectile, MaxProjectile);
        }
        get => projectile;
    }

    public bool[] Stars => stars; //외부에서 별 획득 여부 확인(get property)

    public void GetStar(int index)
    {
        stars[index] = true;

        uiPlayerData.SetStar(index);
    }

    private void Awake()
    {
        //Coin = 0; 
        CurrentProjectile = 0;
    }
}
