using UnityEngine;

public class Movement2D_3 : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f; // �̵� �ӵ�

    [SerializeField]
    private float jumpForce = 8.0f; // ���� �� ( ���� Ŭ ���� ���� �����Ѵ�)
    private Rigidbody2D rigid2D;

    [HideInInspector] // public Ÿ���� ������ Inspector View�� ������ �ʰ� ����
    public bool isLongJump = false; // ���� ����, ���� ���� üũ

    // ���� ���� ����
    [SerializeField]
    private LayerMask groundLayer; // �ٴ� üũ�� ���� �浹 ���̾�
    private CapsuleCollider2D capsuleCollider2D; // ������Ʈ�� �浹 ���� ������Ʈ
    private bool isGrounded; // �ٴ� üũ (�ٴڿ� ������� �� true)
    private Vector3 footPosition; // ���� ��ġ

    // �ִ� ���� Ƚ�� ����
    [SerializeField]
    private int maxJumpCount = 2; // ���� �����ϱ� �� �� �� �ִ� �ִ� ���� Ƚ��
    private int currentJumpCount = 0; // ���� ������ ���� Ƚ��

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();  
    }

    private void FixedUpdate() // PlayerController_2 26��° �� ����
    {
        // ���� ����, ���� ���� ������ ���� �߷� ���(gravityScale) ����
        // Jump Up�� ���� ����
        // �߷� ����� ���� if ���� ���� ������ �ǰ�, �߷� ����� ���� else���� ���� ������ ��
        if (isLongJump && rigid2D.velocity.y > 0) // ���� ����
        {
            rigid2D.gravityScale = 1.0f;
        }
        else // ���� ���� (���� Ű ��� ������ ������)
        {
            rigid2D.gravityScale = 2.5f;
        }

        // �÷��̾� ������Ʈ�� Collider2D min, center, max ��ġ ����
        Bounds bounds = capsuleCollider2D.bounds;
        // �÷��̾� �� ��ġ ����
        footPosition = new Vector3(bounds.center.x, bounds.min.y);
        // �÷��̾��� �� ��ġ�� ���� �����ϰ�, ���� �ٴڰ� ��������� isGrounded = true
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer); // ������ ���̾ �����ؼ� �ش� ������ �浹�� ������Ʈ ���� �Լ�

        // �÷��̾��� ���� ���� ��� �ְ�, y�� �ӵ��� 0�����̸� ���� Ƚ�� �ʱ�ȭ
        // velocity.y <= 0�� �߰����� ������, ���� Ű�� ������ �������� �ʱ�ȭ�� �Ǿ�
        // �ִ� ���� Ƚ���� 2�� �����ϸ� 3������ ������ �����ϰ� �ȴ�. 0��0
        if (isGrounded == true && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;
        }

    }

    public void Move(float x)
    {
        // x�� �̵��� x * speed��, y�� �̵��� ������ �ӷ� ��(����� �߷�)
        rigid2D.velocity = new Vector2 (x * speed, rigid2D.velocity.y);
    }

    public void Jump() // PlayerController_2 20��° �� ����
    {
        //if (isGrounded == true)
        if(currentJumpCount > 0)
        {
            // jumpForce�� ũ�⸸ŭ ���� �������� �ӷ� ����
            rigid2D.velocity = Vector2.up * jumpForce;

            // ���� Ƚ�� 1 ����
            currentJumpCount--;
        }
        
    }

    // ȭ�鿡 ������ �ʴ� �浹 ���� ���� �͵��� �� ��ġ�ߴ��� Ȯ���ϰ� ���� ��
    // ��, �簢��, �� ���� �׷��� Ȯ���ϴ� �뵵
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }
}
