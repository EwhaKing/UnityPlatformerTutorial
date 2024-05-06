using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl2 : MonoBehaviour //이동, 점프
{
    private MoveObj movement2D;

    private void Awake()
    {
        movement2D = GetComponent<MoveObj>();
    }

    private void Update()
    {
        //플레이어 이동
        //left or a=-1, right or d=1
        float x = Input.GetAxisRaw("Horizontal");
        //좌우 이동방향 제어
        movement2D.Move(x);

        //플레이어 점프(스페이스 키)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement2D.Jump();
        }

        if (Input.GetKey(KeyCode.Space))//스페이스 누르고 있음(long jump)
        {
            movement2D.isLongJump=true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))//스페이스 뗌(short jump)

        {
            movement2D.isLongJump = false;
        }
    }
}
