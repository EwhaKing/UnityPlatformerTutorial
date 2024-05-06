using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.C;

    private MovementRigidbody2D movement;
    private PlayerAnimator playerAnimator;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update()
    {
        // 키 입력 (좌/우 방향 키, x키)
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f;

        // 걷기일 땐 값의 범위가 -0.5~0.5
        // 뛰기일 땐 값의 범위가 -1~1로 설정
        x*= offset; 

        //플레이어의 이동 제어 (좌/우)
        UpdateMove(x);
        //플레이어의 점프 제어
        UpdateJump();  
        //플레이어 애니메이션 재생
        playerAnimator.UpdateAnimation(x);
        //머리/발에 충돌한 오브젝트 처리
        UpdateAboveCollision();
        UpdateBelowCollision();
    }

    private void UpdateMove(float x)
    {
        //플레이어의 물리적 이동 (좌/우)
        movement.MoveTo(x);

        //플레이어의 x축 이동 한계치 설정 (PlayerLimitMinX ~ PlayerLimitMaxX)
        float xPosition = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMinX, stageData.PlayerLimitMaxX);
        transform.position = new Vector2(xPosition, transform.position.y);
    }

    private void UpdateJump()
    {
        if( Input.GetKeyDown(jumpKeyCode) )
        {
            movement.Jump();
        }

        if(Input.GetKey(jumpKeyCode) )
        {
            movement.IsLongJump = true;
        }
        else if (Input.GetKeyUp(jumpKeyCode) )
        {
            movement.IsLongJump = false;
        }
    }

    private void UpdateAboveCollision()
    {
        if(movement.Velocity.y >= 0  && movement.HitAboveObject != null){
            //플레이어의 머리와 오브젝트가 충돌했기 때문에 y축 속력을 0으로 설정
            movement.ResetVelocityY();

            //플레이어의 머리와 충돌한 오브젝트가 Tile일 때 Tile의 속성에 따라 충돌 처리
            //GetComponent<>()로 컴포넌트를 얻어오고, 컴포넌트를 정상적으로 얻어왔는지
            //null 체크를 해서 null이 아닐 때 어떤 처리를 하는 코드의 경우 TryGetComponent<>() 활용

            //TryGetComponent<>() 로 movement.HitAboveObject에 
            //TileBase 컴포넌트가 있는지 검사하고, 컴포넌트가 있으면 out var tile 변수에
            //컴포넌트 정보를 저장한 후 true를 반환해 조건문 내부 코드를 실행

            if(movement.HitAboveObject.TryGetComponent<TileBase>(out var tile) && !tile.IsHit)
            {
                tile.UpdateCollision();
            }
        }
    }

    private void UpdateBelowCollision()
    {
        if(movement.HitBelowObject != null) {

            //Platform_03_OneWay
            if(Input.GetKeyDown(KeyCode.DownArrow)&&movement.HitBelowObject.TryGetComponent<PlatformEffectorExtension>(out var p))
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
