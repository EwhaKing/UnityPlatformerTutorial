using UnityEngine;

public class MoveObj : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float jumpForce = 5.0f; //점프 pw(클수록 높게 점프)
    private Rigidbody2D rigid2D;
    [HideInInspector] //public 타입 변수를 inspector view에 보이지 않게 함
    public bool isLongJump = false; //낮은 점프, 높은 점프 구분용

    [SerializeField]
    private LayerMask groundLayer; //Layer: obj 그려지는 순서 정할 수 있음. obj 충돌에서 지정한 레이어와의 충돌 제외 가능
    private CapsuleCollider2D capsuleCollider2D; //obj 충돌 범위 cmp
    private bool isGrounded; //바닥 체크
    private Vector3 footPos; //발 위치

    [SerializeField]
    private int maxJumpCnt = 2; //땅 밟기 전까지 할 수 있는 최대 점프 횟수
    private int currentJumpCnt = 0; //현재 가능 점프 횟수

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        //플레이어 obj의 Collider2D min, center, max 정보
        Bounds bounds = capsuleCollider2D.bounds;
        //플레이어의 발 위치
        footPos = new Vector2(bounds.center.x, bounds.min.y);
        //플레이어 발 위치에 원 생성-> 원이 바닥과 닿아있으면 isGrounded true
        //footPos 위치에 0.1f 크기만큼의 원 충돌범위 생성
        isGrounded = Physics2D.OverlapCircle(footPos, 0.1f, groundLayer);

        //플레이어 바닥 착지+y축 속도 0 이하-> 점프 횟수 초기화
        //velocity.y<=0 추가 x-> 점프키 누르는 순간에도 초기화 -> 최대 점프 횟수 2로 설정하면 3번까지 점프 가능
        if (isGrounded==true&&rigid2D.velocity.y<=0) {
            currentJumpCnt = maxJumpCnt;
        }

        //낮은 점프, 높은 점프 구현-> 중력 계수(gravityScale) 조절. Jump up일 때만 적용
        //중력 계수 낮은 if문-> 높은 점프, else->낮은 점프
        if(isLongJump&&rigid2D.velocity.y>0) //높은 점프
        {
            rigid2D.gravityScale = 1.0f;
        }
        else//낮은 점프
        {
            rigid2D.gravityScale = 2.5f;
        }
    }

    private void OnDrawGizmos()//화면에 보이지 않는 충돌 범위와 같은 것들을 내가 원하는 위치에 잘 배치했는지 확인하고 싶을 때 그려서 확인하는 용도
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPos,0.1f);
    }

    public void Move(float x)
    {
        //x축 이동: x*speed, y축 이동: 기존 속력값(중력)
        rigid2D.velocity=new Vector2(x*speed,rigid2D.velocity.y);
    }

    public void Jump()
    {
        //if(isGrounded)//플레이어 바닥 밟고 있을 때만 점프 가능
        if(currentJumpCnt>0)
        {
            //jumpforce의 크기만큼 윗쪽 방향으로 속력 설정
            rigid2D.velocity = Vector2.up * jumpForce;
            currentJumpCnt--;//점프횟수 차감
        }
    }
}
