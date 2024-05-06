using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;

    [SerializeField]
    private KeyCode jumpkeyCode = KeyCode.C;

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
    }

    private void UpdateMove(float x)
    {
        //플레이어의 물리적 이동(좌우)
        movement.MoveTo(x);

        //플레이어의 x축 이동 한계치 설정(PlayerLimitMinX~PlayerLimitMaxX)
        float xPosition=Mathf.Clamp(transform.position.x,stageData.PlayerLimitMinX,stageData.PlayerLimitMaxX);
        transform.position=new Vector2(xPosition,transform.position.y);
    }

    private void UpdateJump()
    {
        if(Input.GetKeyDown(jumpkeyCode))
        {
            movement.Jump();
        }
        if (Input.GetKey(jumpkeyCode))
        {
            movement.IsLongJump = true;
        }
        else if(Input.GetKeyUp(jumpkeyCode))
        {
            movement.IsLongJump=false;
        }
    }
}
