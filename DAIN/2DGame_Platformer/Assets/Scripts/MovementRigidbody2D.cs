using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    [Header("LayerMask")]
    [SerializeField]
    private LayerMask groundCheckLayer; // �ٴ� üũ�� ���� �浹 ���̾�

    [Header("Move")]
    [SerializeField]
    private float walkSpeed = 5; // �ȴ� �ӵ�
    [SerializeField]
    private float runSpeed = 8; // �ٴ� �ӵ�

    [Header("Jump")]
    [SerializeField]
    private float jumpForce = 13; // ���� ��
    [SerializeField]
    private float lowGravityScale = 2; // ���� Ű�� ���� ������ ���� �� ����Ǵ� �߷� (���� ����)
    [SerializeField]
    private float highGravityScale = 3.5f; // �Ϲ������� ����Ǵ� �߷� (���� ����)

    private float moveSpeed; // �̵� �ӵ�

    private Vector2 collisionSize; // �Ӹ�, �� ��ġ�� �����ϴ� �浹 �ڽ� ũ��
    private Vector2 footPosition; // �� ��ġ

    private Rigidbody2D rigid2D; // ������ �����ϴ� ������Ʈ
    private Collider2D collider2D; // ���� ������Ʈ�� �浹 ����

    public bool IsLongJump { set; get; } = false; // ���� ����, ���� ���� üũ
    public bool IsGrounded { private set; get; } = false; // �ٴ� üũ (�ٴڿ� ������� �� true)

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        UpdateCollision();
        JumpHeight();
    }

    // x�� �ӷ�(velocity) ����, �ܺ� Ŭ�������� ȣ��
    public void MoveTo(float x)
    {
        // x�� ���밪�� 0.5�̸� �ȱ�(walkSpeed), 1�̸� �ٱ�(runSpeed)
        moveSpeed = Mathf.Abs(x) != 1 ? walkSpeed : runSpeed;

        // x�� -0.5, 0.5�� ���� ���� �� x�� -1, 1�� ����
        if (x != 0) x = Mathf.Sign(x);

        // x�� ���� �ӷ��� x * moveSpeed�� ����
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    private void UpdateCollision()
    {
        // �÷��̾� ������Ʈ�� Collider2D min, center, max ��ġ ����
        Bounds bounds = collider2D.bounds;

        // �÷��̾� �߿� �����ϴ� �浹 ����
        collisionSize = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);

        // �÷��̾��� �� ��ġ
        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        // �÷��̾ �ٴ��� ��� �ִ��� üũ�ϴ� �浹 �ڽ�
        IsGrounded = Physics2D.OverlapBox(footPosition, collisionSize, 0, groundCheckLayer);
            // Physics2D.OverlapBox(Vector2 point, Vector2 size, float angle, int layerMask);
            // point ��ġ�� size ũ���� �浹 �ڽ�(BoxCollider2D)�� angle ������ŭ ȸ���ؼ� ����
            // �� �浹 �ڽ��� layerMask�� ������ ���̾ �浹�� ����      
    }

    // �ٸ� Ŭ�������� ȣ���ϴ� ���� �޼ҵ�
    // y�� ����
    public void Jump()
    {
        if (IsGrounded == true)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
        }
    }

    private void JumpHeight()
    {
        // ���� ����, ���� ���� ������ ���� �߷� ���(gravityScale) ���� (Jump Up�� ���� ����ȴ�)
        // �߷� ����� ���� if���� ���� ������ �ǰ�, �߷� ����� ���� else ���� ���� ������ �ȴ�
        if (IsLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = lowGravityScale;
        }
        else
        {
            rigid2D.gravityScale = highGravityScale;
        }
    }
}
   
