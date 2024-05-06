using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //스테이지 정보를 바탕으로 플레이어의 x축 이동 범위를 제한하기 위한 변수
    [SerializeField]
    StageData stageData;
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
        UpdateMove(x);


        //플레이어 점프 제어
        UpdateJump();

        //플레이어 애니메이션 제어
        playerAnimator.UpdateAnimation(x);


        //머리/발에 충돌한 오브젝트 처리
        UpdateAboveCollision();
        UpdateBelowCollision();

    }

    void UpdateMove(float x)
    {
        movement.MoveTo(x);
        //플레이어 x축 이동 한계치 설정(PlayerLimitMixX ~ PlayerLimitMaxX)
        float xPosition = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMixX, stageData.PlayerLimitMaxX);
        transform.position = new Vector2(xPosition, transform.position.y);
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

    void UpdateAboveCollision()
    {
        //플레이어의 y 속력이 0 이상으로 위로 점프하고 있을 때 머리에 충돌하는 오브젝트가 있으면
        //movement.ResetVelocityY() 메소드를 호출해 플레이어의 y 속력을 0으로 설정해 아래로 떨어지도록 한다.

        if (movement.Velocity.y >= 0 && movement.HitAboveObject != null)
        {
            movement.ResetVelocityY();

            //플레이어의 머리와 충돌한 오브젝트가 Tile일 때 Tile의 속성에 따라 충돌 처리
            //movement.HitAboveObject에 TileBase 컴포넌트가 있는지 검사하고,
            //있다면 'out var tile 변수에 컴포넌트 정보를 저장'하고 true를 반환해 조건문 내부 코드를 실행하도록 한다.
            if (movement.HitAboveObject.TryGetComponent<TileBase>(out var tile) && !tile.IsHit)
            {
                //tile의 IsHit이 false 일 때만 호출되도록 조건 추가

                //반환된 tile 변수의 UpdateCollision() 메소드를 호출한다.
                tile.UpdateCollision();

            }

            //Tip : GetComponent<>()로 컴포넌트를 얻어오고, 컴포넌트를 정상적으로 얻어왔는지 null 체크를 해서 null이 아닐 때 어떤 처리를 하는 코드의 경우
            //TryGetComponent<>()를 활용하면 된다.
        }
    }


    void UpdateBelowCollision()
    {
        if (movement.HitBelowObject != null)
        {
            //Platform_03_Oneway
            if (Input.GetKeyDown(KeyCode.DownArrow) && movement.HitBelowObject.TryGetComponent<PlatformEffectorExtension>(out var p))
            {
                p.OnDownWay();
            }
            if (movement.HitBelowObject.TryGetComponent<PlatformBase>(out var platform))
            {
                platform.UpdateCollision(gameObject);
            }
        }
    }
}
