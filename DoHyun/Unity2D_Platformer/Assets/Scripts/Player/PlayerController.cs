using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //입력 키에 따라 오브젝트를 이동하는 컴포넌트의 메소드를 호출하여 플레이어의 이동을 제어하도록 구현한다.

    [SerializeField]
    KeyCode jumpKeyCode = KeyCode.C;
    MovementRigidbody2D movement;
    PlayerAnimator playerAnimator;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); //GetAxisRaw를 사용해야한다.
        //GetAxisRaw는 사용자의 입력을 선형적으로 처리하지 않고, 원시 입력 값 그대로를 반환한다.
        //-1,0,1과 같은 고정된 값 만을 반환한다.
        //사용자의 입력에 대해 더 빠르게 반응할 수 있다.

        //반변 GetAxis는 입력 값을 선형 보간하여 반환한다. 사용자 입력을 부드럽게 처리하기 위해 사용된다.
        //사용자가 입력을 조금씩 변경할 때마다 값이 조금씩 변화한다.
        //조이스틱, 트리거 같은 아날로그 입력 장치에 사용된다.


        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f; //누르지 않으면 0.5, 누르면 1이 되도록 한다.

        x *= offset; //걷기는 -0.5~0.5 , 뛰기는 -1~1이 되도록한다.

        //플레이어 이동 제어
        movement.MoveTo(x); //함수 만들지 않고 그냥 바로 코드 사용하도록 함


        //플레이어 점프 제어
        UpdateJump();

        //플레이어 애니메이션 제어
        playerAnimator.UpdateAnimation(x);

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
