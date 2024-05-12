using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStar : ItemBase
{
    //[Tooltip(string desc)]:인스펙터 창에서 해당 변수에 마우스를 hover했을 때 desc 내용을 출력한다.
    [Tooltip("별 아이템은 한 맵에 항상 3개를 배치하고, 0, 1, 2, 순번 부여")]
    //[Range(int min, int max)] : 해당 변수에 입력할 수 있는 값의 범위를 min~max로 설정, Slider ui를 이용해 값 설정 가능
    [SerializeField][Range(0, 2)] private int starIndex;
    public override void UpdateCollision(Transform target)
    {
        target.GetComponent<PlayerData>().GetStar(starIndex);
    }


}
