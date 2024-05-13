using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private StageData stageData;

	[SerializeField] // 입력하는 키 값을 변수로 선언해두면 키 수정할 때 편리하다
	private	KeyCode				jumpKeyCode = KeyCode.C;
    [SerializeField]
    private KeyCode fireKeyCode = KeyCode.Z;

    private	MovementRigidbody2D	movement;
	private PlayerAnimator playerAnimator;
    private PlayerWeapon weapon;
    private PlayerData playerData;

    private int lastDirectionX = 1;

    private void Awake()
	{
		movement		= GetComponent<MovementRigidbody2D>();
		playerAnimator = GetComponentInChildren<PlayerAnimator>();
        weapon = GetComponent<PlayerWeapon>();
        playerData = GetComponent<PlayerData>();
    }

	private void Update()
	{
		// 키 입력 (좌/우 방향 키, x 키)
		float x		 = Input.GetAxisRaw("Horizontal");
		float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f; // x키 누르고 있으면 1, x 키 안 누르고 있으면 0.5

        if (x != 0) lastDirectionX = (int)x;

        // 걷기일 땐 값의 범위가 -0.5 ~ 0.5
        // 뛰기일 땐 값의 범위가 -1 ~ 1로 설정
        x *= offset;

		// 플레이어의 이동 제어 (좌/우)
		UpdateMove(x);
		// 플레이어의 점프 제어
		UpdateJump();
		// 플레이어 애니메이션 재생
		playerAnimator.UpdateAnimation(x);
        // 머리/발에 충돌한 오브젝트 처리
        UpdateAboveCollision();
        UpdateBelowCollision();
        // 원거리 공격 제어
        UpdateRangeAttack();
    }

	private void UpdateMove(float x)
	{
		// 플레이어의 물리적 이동 (좌/우)
		movement.MoveTo(x); // x 값에 따라 플레이어가 대기, 걷기, 뛰기를 한다

		// 플레이어의 x축 이동 한계치 설정 (PlayerLimitMinX ~ PlayerLimitMaxX)
		float xPosition = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMinX, stageData.PlayerLimitMaxX);
		transform.position = new Vector2(xPosition, transform.position.y);
	}

	private void UpdateJump()
	{
		if ( Input.GetKeyDown(jumpKeyCode) ) // 점프 키 누름
		{
			movement.Jump();
		}

		if ( Input.GetKey(jumpKeyCode) ) // 점프 키 누르고 있음
		{
			movement.IsLongJump = true;
		}
		else if ( Input.GetKeyUp(jumpKeyCode) ) // 점프 키 뗌
		{
			movement.IsLongJump = false;
		}
	}
    private void UpdateAboveCollision()
    {
        if (movement.Velocity.y >= 0 && movement.HitAboveObject != null)
        {
            // 플레이어의 머리와 오브젝트가 충돌했기 때문에 y축 속력을 0으로 설정
            movement.ResetVelocityY();

			// 플레이어의 머리와 충돌한 오브젝트가 Tile일 때 Tile의 속성에 따라 충돌 처리
			if (movement.HitAboveObject.TryGetComponent<TileBase>(out var tile) && !tile.IsHit)
				// TryGetComponent<>()로 movement.HitAboveObject에 TileBase 컴포넌트가 있는지 검사하고,
				// 컴포넌트가 있으면 out var tile 변수에 컴포넌트 정보 저장 후 true 반환 -> 조건문 내부 코드 실행
			{
				tile.UpdateCollision();
			}
		}
    }

	private void UpdateBelowCollision()
	{
		if (movement.HitBelowObject != null)
		{
			// Platform_03_OneWay
			if (Input.GetKeyDown(KeyCode.DownArrow) && movement.HitBelowObject.TryGetComponent<PlatformEffectorExtension>(out var p))
			{
				p.OnDownWay();
			}

			if (movement.HitBelowObject.TryGetComponent<PlatformBase>(out var platform ))
			{
				platform.UpdateCollision(gameObject);
			}
		}
	}

    private void UpdateRangeAttack()
    {
        if (Input.GetKeyDown(fireKeyCode) && playerData.CurrentProjectile > 0)
        {
            playerData.CurrentProjectile--;

            weapon.StartFire(lastDirectionX);
        }
    }
}

