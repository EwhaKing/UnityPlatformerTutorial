using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private StageData stageData;

	[SerializeField] // 입력하는 키 값을 변수로 선언해두면 키 수정할 때 편리하다
	private	KeyCode				jumpKeyCode = KeyCode.C;

	private	MovementRigidbody2D	movement;
	private PlayerAnimator playerAnimator;

	private void Awake()
	{
		movement		= GetComponent<MovementRigidbody2D>();
		playerAnimator = GetComponentInChildren<PlayerAnimator>();
	}

	private void Update()
	{
		// 키 입력 (좌/우 방향 키, x 키)
		float x		 = Input.GetAxisRaw("Horizontal");
		float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f; // x키 누르고 있으면 1, x 키 안 누르고 있으면 0.5
		
		// 걷기일 땐 값의 범위가 -0.5 ~ 0.5
		// 뛰기일 땐 값의 범위가 -1 ~ 1로 설정
		x *= offset;

		// 플레이어의 이동 제어 (좌/우)
		UpdateMove(x);
		// 플레이어의 점프 제어
		UpdateJump();
		// 플레이어 애니메이션 재생
		playerAnimator.UpdateAnimation(x);
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
}

