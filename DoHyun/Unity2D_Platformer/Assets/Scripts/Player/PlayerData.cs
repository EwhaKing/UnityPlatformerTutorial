using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private UIPlayerData uIPlayerData;
    [SerializeField]
    private int coin = 0;
    [SerializeField]
    private int projectile = 0;
    [SerializeField]
    private bool[] starts = new bool[3] { false, false, false };
    public int Coin
    {
        set
        {
            coin = Mathf.Clamp(value, 0, 9999); //0~9999개 사이로 제한
            uIPlayerData.SetCoin(coin);

        }
        get => coin;
    }

    //get만 가능한 property이기 때문에 readonly/const와 같이 수정 불가능
    public int MaxProjectile { get; } = 10;
    public int CurrentProjectile
    {
        set
        {
            projectile = Mathf.Clamp(value, 0, MaxProjectile);
            uIPlayerData.SetProjectile(projectile, MaxProjectile);
        }
        get => projectile;
    }

    public void GetStar(int index)
    {
        starts[index] = true;
        uIPlayerData.SetStar(index);
    }

    private void Awake()
    {
        Coin = 0;
        CurrentProjectile = 0;
    }
}
