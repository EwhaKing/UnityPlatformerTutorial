using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private StageData stageData;

	[SerializeField] // �Է��ϴ� Ű ���� ������ �����صθ� Ű ������ �� ���ϴ�
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
		// Ű �Է� (��/�� ���� Ű, x Ű)
		float x		 = Input.GetAxisRaw("Horizontal");
		float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f; // xŰ ������ ������ 1, x Ű �� ������ ������ 0.5

        if (x != 0) lastDirectionX = (int)x;

        // �ȱ��� �� ���� ������ -0.5 ~ 0.5
        // �ٱ��� �� ���� ������ -1 ~ 1�� ����
        x *= offset;

		// �÷��̾��� �̵� ���� (��/��)
		UpdateMove(x);
		// �÷��̾��� ���� ����
		UpdateJump();
		// �÷��̾� �ִϸ��̼� ���
		playerAnimator.UpdateAnimation(x);
        // �Ӹ�/�߿� �浹�� ������Ʈ ó��
        UpdateAboveCollision();
        UpdateBelowCollision();
        // ���Ÿ� ���� ����
        UpdateRangeAttack();
    }

	private void UpdateMove(float x)
	{
		// �÷��̾��� ������ �̵� (��/��)
		movement.MoveTo(x); // x ���� ���� �÷��̾ ���, �ȱ�, �ٱ⸦ �Ѵ�

		// �÷��̾��� x�� �̵� �Ѱ�ġ ���� (PlayerLimitMinX ~ PlayerLimitMaxX)
		float xPosition = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMinX, stageData.PlayerLimitMaxX);
		transform.position = new Vector2(xPosition, transform.position.y);
	}

	private void UpdateJump()
	{
		if ( Input.GetKeyDown(jumpKeyCode) ) // ���� Ű ����
		{
			movement.Jump();
		}

		if ( Input.GetKey(jumpKeyCode) ) // ���� Ű ������ ����
		{
			movement.IsLongJump = true;
		}
		else if ( Input.GetKeyUp(jumpKeyCode) ) // ���� Ű ��
		{
			movement.IsLongJump = false;
		}
	}
    private void UpdateAboveCollision()
    {
        if (movement.Velocity.y >= 0 && movement.HitAboveObject != null)
        {
            // �÷��̾��� �Ӹ��� ������Ʈ�� �浹�߱� ������ y�� �ӷ��� 0���� ����
            movement.ResetVelocityY();

			// �÷��̾��� �Ӹ��� �浹�� ������Ʈ�� Tile�� �� Tile�� �Ӽ��� ���� �浹 ó��
			if (movement.HitAboveObject.TryGetComponent<TileBase>(out var tile) && !tile.IsHit)
				// TryGetComponent<>()�� movement.HitAboveObject�� TileBase ������Ʈ�� �ִ��� �˻��ϰ�,
				// ������Ʈ�� ������ out var tile ������ ������Ʈ ���� ���� �� true ��ȯ -> ���ǹ� ���� �ڵ� ����
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

