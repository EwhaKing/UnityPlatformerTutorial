using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.C;

    private MovementRigidbody2D movement;
    private PlayerAnimator playerAnimator;

    private void Awake() {
        movement = GetComponent<MovementRigidbody2D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update() {
        // 키 입력 (좌우방향 키, 왼쪽 shift키)
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f;

        // 걷기일 땐 값의 범위가 -0.5 ~ 0.5
        // 뛰기일 땐 값의 범위가 -1 ~ 1
        x *= offset;

        // 플레이어의 이동 제어(좌/우)
        UpdateMove(x);

        // 플레이어의 점프 제어
        UpdateJump();

        // 플레이어 애니메이션 제어
        playerAnimator.UpdateAnimation(x);

        // 머리에 충돌한 오브젝트 처리
        UpdateAboveCollision();

        // 발에 충돌한 오브젝트 처리
        UpdateBelowCollision();
    }

    private void UpdateMove(float x){
        movement.MoveTo(x);

        float xPosition = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMinX, stageData.PlayerLimitMaxX);
        transform.position = new Vector2(xPosition, transform.position.y);
    }

    private void UpdateJump() {
        if(Input.GetKeyDown(jumpKeyCode)){
            movement.Jump();
        }

        if(Input.GetKey(jumpKeyCode)){
            movement.IsLongJump = true;
        }

        else if (Input.GetKeyUp(jumpKeyCode)){
            movement.IsLongJump = false;
        }
    }

    private void UpdateAboveCollision() {
        if (movement.Velocity.y >= 0 && movement.HitAboveObject != null)
        {
            // 플레이어의 머리와 오브젝트가 충돌했기 때문에 y축 속력을 0으로 설정
            movement.ResetVelocityY();

            // 플레이어의 머리와 충돌한 오브젝트가 Tile일 때 Tile의 속성에 따라 충돌 처리
            if(movement.HitAboveObject.TryGetComponent<TileBase>(out var tile) && !tile.IsHit)
            {
                tile.UpdateCollision();
            }
        }
    }

    private void UpdateBelowCollision() {
        if(movement.HitBelowObject != null)
        {
            //Platform_03_Oneway
            if (Input.GetKeyDown(KeyCode.DownArrow) && movement.HitBelowObject.TryGetComponent<PlatformEffectorExtension>(out var p))
            {
                p.OnDownWay();
            }

            if(movement.HitBelowObject.TryGetComponent<PlatformBase>(out var platform))
            {
                platform.UpdateCollision(gameObject);
            }
        }
    }

}
