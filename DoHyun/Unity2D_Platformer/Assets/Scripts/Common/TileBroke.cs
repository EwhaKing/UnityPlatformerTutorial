using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBroke : TileBase
{
    //타일 부서지는 효과를 재생하기 위해 파티클 오브젝트를 저장하는 변수 선언
    [Header("Tile Broke")]
    [SerializeField]
    private GameObject tileBrokeEffect;


    public override void UpdateCollision()
    {
        //부모 클래스의 UpdateCollision() 호출
        base.UpdateCollision();

        //타일이 부서지는 파티클 생성(오버라이딩 부분)
        Instantiate(tileBrokeEffect, transform.position, Quaternion.identity);

        //타일 오브젝트 삭제
        Destroy(gameObject);
    }
}
