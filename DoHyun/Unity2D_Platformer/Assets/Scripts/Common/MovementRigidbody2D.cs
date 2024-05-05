using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{

    //[Header("Text")] : 괄호 내부 문자열을 인스펙터 창에 굵은 글씨로 표시해준다.
    [Header("LayerMask")]
    [SerializeField]
    private LayerMask groundCheckLayer; //바닥 체크를 위한 충돌 레이어
    [SerializeField]
    private LayerMask aboveCollisionLayer; //머리 충돌 체크를 위한 레이어
    [SerializeField]
    private LayerMask belowCollisionLayer; //발 충돌 체크를 위한 레이어

    [Header("Move")]
    [SerializeField]
    private float walkSpeed = 5; // 걷는 속도
    [SerializeField]
    private float runSpeed = 8; //달리는 속도

    [Header("Jump")]
    [SerializeField]
    private float jumpForce = 13; //점프 힘
    [SerializeField]
    private float lowGravityScale = 2; //높은 점프(점프 키 오래 누르고 있을 때) -> gravity sacale이 적을 수록 중력의 영향을 적게 받는것!
    [SerializeField]
    private float highGravityScale = 3.5f; //낮은 점프(일반 점프)

    private float moveSpeed; //이동 속도

    //바닥 착지 직전 조금 빨리 점프 키를 눌렀을 때 바닥에 착지하면 바로 점프가 되도록 추가 구현
    //선입력을 할 수 있는 한계 시간을 나타내는 변수와 시간 계산을 위한 변수를 선언한다.
    private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

    //낭떠러지에서 떨어질 때 아주 잠시 동안 점프가 가능하도록 설정하기 위한 변수
    float hangTime = 0.2f;
    float hangCounter;
    private Vector2 collisionSize; //머리, 발 위치에 생성하는 충돌 박스 크기
    private Vector2 footPosition; //발 위치
    private Vector2 headPosition; //머리 위치

    private Rigidbody2D rigid2D;
    private Collider2D col2D;

    public bool IsLongJump { set; get; } = false; //낮은 점프, 높은 점프 체크
    public bool IsGrounded { private set; get; } = false; //바닥 체크

    //머리에 충돌한 오브젝트를 저장하는 Collider2D 프로퍼티
    public Collider2D HitAboveObject { get; private set; }

    //발에 충돌한 오브젝트를 저장하는 Collider2D 프로퍼티. 충돌 여부를 MovementRigidbody2D에서 검사하기 때문에 set은 현재 클리스에서만 할 수 있도록 private으로 설정한다.
    public Collider2D HitBelowObject { get; private set; }

    //애니메이션을 위한 플레이어 속도를 반환하는 프로퍼티 Velocity를 정의한다.
    //이 프로퍼티를 사용하여 플레이어 캐릭터의 애니메이션을 제어한다.
    public Vector2 Velocity => rigid2D.velocity;

    private void Awake()
    {
        //초기 : 이동 속도를 걷는 속도로 설정
        moveSpeed = walkSpeed;
        //오브젝트의 컴포넌트를 사용하기 위해서는
        //프로그램이 실행되면 가장 먼저 호출되는 awake 함수에서 GetComponent 메소드를 사용해서 컴포넌트를 가져와야 한다.
        rigid2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<Collider2D>();
    }

    /// <summary>
    /// x축 속력(velocity)을 설정하는 메소드. 외부 클래스에서 호출
    /// </summary>
    /// <param name="x"></param>
    public void MoveTo(float x)
    {
        //Point : 움직이게 한다, 속력을 조절한다 -> rigidbody를 사용해 컨트롤하자.


        //움직이는 속도 = 절대값이 0.5면 걷기, 1이면 뛰기.
        moveSpeed = Mathf.Abs(x) == 0.5 ? walkSpeed : runSpeed;

        //x값의 부호에 따라 이동 병향 결정 (x가 0이면 정지이니까 그 외 경우에만 방향을 결정해주어야 한다.)
        if (x != 0)
        {
            x = Mathf.Sign(x); //인자가 0, 양수면 1 반환 음수면 -1 반환
        }

        //마지막에 리지드바디의 속도를 바꿀 때 이동 방향을 결정하는 부호를 이동 속도에 곱해준다!
        //velocity 2차원 벡터로 전달해야한다.
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    //플레이어 이동에 따라 coliison 위치가 변경되므로 매번 충돌박스를 생성하고 바닥인지 체크하도록 해야한다.
    private void UpdateCollision()
    {
        Bounds bounds = col2D.bounds; //플레이어 오브젝트의 Collider2D의 min, max, center의 위치 정보를 가져온다.
        //이를 통해 머리, 발에 충돌 범위를 설정, 발 위치 설정 -> 바닥 충돌 감지한다.

        //1.충돌 박스 크기 구하기
        collisionSize = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);
        //2. 발 위치 설정하기
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        headPosition = new Vector2(bounds.center.x, bounds.max.y);

        //3. 바닥인지 체크 -> 물리 충돌박스의 overlap?
        IsGrounded = Physics2D.OverlapBox(footPosition, collisionSize, 0, groundCheckLayer); //groundCheckLayer : 바닥 충돌 체크 레이어
        HitAboveObject = Physics2D.OverlapBox(headPosition, collisionSize, 0, aboveCollisionLayer);
        HitBelowObject = Physics2D.OverlapBox(footPosition, collisionSize, 0, belowCollisionLayer);

        //Physics2D.OverlapBox(Vector2 point, Vector2 size, float angle, int layerMask)
        //point 위치에 size 만큼의 충돌 박스(BoxCollider2D)를 angle 각도 만큼 회전해서 생성한다.
        //이 박스는 layerMask에 설정된 레이어만 충돌 감지한다.
        //반환 값을 bool로 받으면 충돌 여부에 따라 true/false를 반환하고
        //Collider2D hitObject로 받으면 충돌한 오브젝트의 Collider 정보를 반환한다. 여러 개의 충돌 오브젝트가 존재하는 경우 OverlapBoxAll 메소드를 사용해 배열로 받으면 된다.

    }

    /// <summary>
    /// 마찬가지로 다른 클래스에서 호출하는 점프 메소드이다. y축 점프
    /// </summary>
    public void Jump() //점프 카운트를 시작점으로 셋팅하기 때문에 점프임!
    {
        // if (IsGrounded == true)
        // {
        //     rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        // }
        jumpBufferCounter = jumpBufferTime;
    }

    //외부에서 점프힘(force)을 설정해서 호출하는 JumpTo() 메소드
    public void JumpTo(float force)
    {
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, force);
    }

    //낮은 점프, 높은 점프 구현을 위해 중력 계수를 조절
    private void JumpHeight()
    {
        //longJump이고, 점프 하는 중(올라가는 중)
        if (IsLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = lowGravityScale;
        }
        else
        {
            rigid2D.gravityScale = highGravityScale;
        }
    }

    void JumpAdditive()
    {
        //낭떠러지에서 떨어질 때 아주 잠시동안 점프가 가능하도록 설정
        if (IsGrounded) hangCounter = hangTime;
        else hangCounter -= Time.deltaTime;

        //점프 중에 점프 키가 선입력 되었고, 점프 버터 설정 시간 이내에 선입력 된 것이라면 = 0.1초 후에 바닥에 닿은 것이라면, 다시 점프한다.
        //점프하면 jumpBufferCounter=jumpBuffer가 되므로 >0를 만족한다.
        if (jumpBufferCounter > 0)
        {
            jumpBufferCounter -= Time.deltaTime; //업데이트 함수에서 매 프레임마다 이 값이 감소한다.
        }
        if (jumpBufferCounter > 0 && hangCounter > 0) //time.deltaTime 이 지나기 전에 점프 키가 또 눌린것? 
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
            jumpBufferCounter = 0;
            hangCounter = 0;
        }
    }

    public void ResetVelocityY()
    {
        //플레이어의 y 속력을 0으로 설정한다.
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
    }



    private void Update()
    {
        UpdateCollision();
        JumpHeight();
        JumpAdditive();

    }

}
