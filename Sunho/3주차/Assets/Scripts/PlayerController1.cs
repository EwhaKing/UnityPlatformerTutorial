using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField]
    /// 입력하는 키 값을 별도의 변수로 선언해두면 키수정이 편리하다.
    private KeyCode jumpKeyCode = KeyCode.C;

    private MovementRigidbody2D movement;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
    }

    private void Update()
    {
        // 키 입력 (좌/우 방향 키, x 키)
        float x     = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Sprint")*0.5f;

        // 걷기일 땐 값의 번위가 -0.5~0.5
        // 뛰기일 땐 값의 범위가 -1~1로 설정
        x *= offset;

        // 플레이어의 이동 제어 (좌/우)
        UpdateMove(x);
        // 플레이어의 점프 제어
        UpdateJump();
    }

    private void UpdateMove(float x)
    {
        // 플레이어의 물리적 이동 (좌/우)
        movement.MoveTo(x);
    }

    private void UpdateJump()
    {
        if ( Input.GetKeyDown(jumpKeyCode) )
        {
            movement.Jump();
        }
        if ( Input.GetKey(jumpKeyCode))
        {
            movement.IsLongJump = true;
        }
        else if ( Input.GetKeyUp(jumpKeyCode))
        {
            movement.IsLongJump = false;
        }
    }

}

}
