using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;

    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.C;

    private MovementRigidbody2D movement;

    //플레이어의 키 입력에 따라 애니메이션 재생 제어하기 위해
    private PlayerAnimator playerAnimator;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();

        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //키 입력(좌우 방향키, x키)
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f;

        //걷기일 때 값의 범위: -0.5~0.5
        //뛰기일 때 값의 범위: -1~1
        x *= offset;

        //플레이어의 이동 제어(좌우)
        UpdateMove(x);

        //플레이어의 점프 제어
        UpdateJump();

        //플레이어 애니메이션 재생
        playerAnimator.UpdateAnimation(x);

        //머리에 충돌한 obj 처리
        UpdateAboveCollision();
        UpdateBelowCollision();
    }

    private void UpdateMove(float x)
    {
        //플레이어의 물리적 이동(좌우)
        movement.MoveTo(x);

        //플레이어의 x축 이동 한계치 설정(PlayerLimitMinX~PlayerLimitMaxX)
        float xPosition = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMinX, stageData.PlayerLimitMaxX);
        transform.position = new Vector2(xPosition, transform.position.y);
    }

    private void UpdateJump()
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
    }

    private void UpdateAboveCollision()
    {
        if (movement.Velocity.y >= 0 && movement.HitAboveObject != null)
        {
            //플레이어 머리와 obj 충돌-> y축 속력을 0으로(땅으로 떨어짐)
            movement.ResetVelocityY();

            //플레이어의 머리와 충돌한 obj가 tile일 때 tile의 속성에 따라 충돌 처리
            if (movement.HitAboveObject.TryGetComponent<TileBase>(out var tile) && !tile.IsHit)
            {
                tile.UpdateCollision();
            }
        }
    }

    private void UpdateBelowCollision()
    {
        if (movement.HitBelowObject != null)
        {
            //Platform_03_Oneway
            if(Input.GetKeyDown(KeyCode.DownArrow)&&movement.HitBelowObject.TryGetComponent<PlatformEffectorExtension>(out var p))
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
