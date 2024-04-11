using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //입력 키에 따라 오브젝트를 이동하는 컴포넌트의 메소드를 호출하여 플레이어의 이동을 제어하도록 구현한다.

    [SerializeField]
    KeyCode jumpKeyCode = KeyCode.C;
    MovementRigidbody2D movement;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f; //누르지 않으면 0.5, 누르면 1이 되도록 한다.

        x *= offset; //걷기는 -0.5~0.5 , 뛰기는 -1~1이 되도록한다.

        //플레이어 이동 제어
        movement.MoveTo(x); //함수 만들지 않고 그냥 바로 코드 사용하도록 함


        //플레이어 점프 제어
        UpdateJump();

    }


    void UpdateJump()
    {
        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement.Jump();
        }

        if (Input.GetKey(jumpKeyCode))
        {
            movement.IsLongJump = true;
        }
        else if (Input.GetKeyUp(jumpKeyCode))
        {
            movement.IsLongJump = false;
        }

        //누르고 있으면~ 높은 점프, 그게 아니고 키가 떼졌으면 일반 점프
    }
}
