using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl2 : MonoBehaviour //�̵�, ����
{
    private MoveObj movement2D;

    private void Awake()
    {
        movement2D = GetComponent<MoveObj>();
    }

    private void Update()
    {
        //�÷��̾� �̵�
        //left or a=-1, right or d=1
        float x = Input.GetAxisRaw("Horizontal");
        //�¿� �̵����� ����
        movement2D.Move(x);

        //�÷��̾� ����(�����̽� Ű)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement2D.Jump();
        }

        if (Input.GetKey(KeyCode.Space))//�����̽� ������ ����(long jump)
        {
            movement2D.isLongJump=true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))//�����̽� ��(short jump)

        {
            movement2D.isLongJump = false;
        }
    }
}
