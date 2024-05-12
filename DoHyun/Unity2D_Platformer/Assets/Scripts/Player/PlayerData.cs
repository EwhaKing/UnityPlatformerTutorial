using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int coin = 0;
    public int Coin
    {
        set => coin = Mathf.Clamp(value, 0, 9999); //0~9999개 사이로 제한
        get => coin;
    }
}
