using UnityEngine;

public class MoveObj : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float jumpForce = 5.0f; //���� pw(Ŭ���� ���� ����)
    private Rigidbody2D rigid2D;
    [HideInInspector] //public Ÿ�� ������ inspector view�� ������ �ʰ� ��
    public bool isLongJump = false; //���� ����, ���� ���� ���п�

    [SerializeField]
    private LayerMask groundLayer; //Layer: obj �׷����� ���� ���� �� ����. obj �浹���� ������ ���̾���� �浹 ���� ����
    private CapsuleCollider2D capsuleCollider2D; //obj �浹 ���� cmp
    private bool isGrounded; //�ٴ� üũ
    private Vector3 footPos; //�� ��ġ

    [SerializeField]
    private int maxJumpCnt = 2; //�� ��� ������ �� �� �ִ� �ִ� ���� Ƚ��
    private int currentJumpCnt = 0; //���� ���� ���� Ƚ��

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        //�÷��̾� obj�� Collider2D min, center, max ����
        Bounds bounds = capsuleCollider2D.bounds;
        //�÷��̾��� �� ��ġ
        footPos = new Vector2(bounds.center.x, bounds.min.y);
        //�÷��̾� �� ��ġ�� �� ����-> ���� �ٴڰ� ��������� isGrounded true
        //footPos ��ġ�� 0.1f ũ�⸸ŭ�� �� �浹���� ����
        isGrounded = Physics2D.OverlapCircle(footPos, 0.1f, groundLayer);

        //�÷��̾� �ٴ� ����+y�� �ӵ� 0 ����-> ���� Ƚ�� �ʱ�ȭ
        //velocity.y<=0 �߰� x-> ����Ű ������ �������� �ʱ�ȭ -> �ִ� ���� Ƚ�� 2�� �����ϸ� 3������ ���� ����
        if (isGrounded==true&&rigid2D.velocity.y<=0) {
            currentJumpCnt = maxJumpCnt;
        }

        //���� ����, ���� ���� ����-> �߷� ���(gravityScale) ����. Jump up�� ���� ����
        //�߷� ��� ���� if��-> ���� ����, else->���� ����
        if(isLongJump&&rigid2D.velocity.y>0) //���� ����
        {
            rigid2D.gravityScale = 1.0f;
        }
        else//���� ����
        {
            rigid2D.gravityScale = 2.5f;
        }
    }

    private void OnDrawGizmos()//ȭ�鿡 ������ �ʴ� �浹 ������ ���� �͵��� ���� ���ϴ� ��ġ�� �� ��ġ�ߴ��� Ȯ���ϰ� ���� �� �׷��� Ȯ���ϴ� �뵵
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPos,0.1f);
    }

    public void Move(float x)
    {
        //x�� �̵�: x*speed, y�� �̵�: ���� �ӷ°�(�߷�)
        rigid2D.velocity=new Vector2(x*speed,rigid2D.velocity.y);
    }

    public void Jump()
    {
        //if(isGrounded)//�÷��̾� �ٴ� ��� ���� ���� ���� ����
        if(currentJumpCnt>0)
        {
            //jumpforce�� ũ�⸸ŭ ���� �������� �ӷ� ����
            rigid2D.velocity = Vector2.up * jumpForce;
            currentJumpCnt--;//����Ƚ�� ����
        }
    }
}
