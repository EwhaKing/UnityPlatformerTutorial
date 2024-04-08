using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_2 : MonoBehaviour
{
    Movement2D_3 movement2D;
    // Start is called before the first frame update

    private void Awake()
    {
        movement2D = GetComponent<Movement2D_3>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //좌우 이동 제어
        movement2D.Move(x);

        //플레이어 점프 (스페이스 키를 누르면 점프)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement2D.Jump();
        }

        //스페이스 키를 누르고 있으면 isLongJump = true
        if (Input.GetKey(KeyCode.Space))
        {
            movement2D.isLongJump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            movement2D.isLongJump = false;
        }

    }
}
