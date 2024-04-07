using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D_3 : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;
    [SerializeField]
    float jumpForce = 8.0f;
    Rigidbody2D rigid2D;

    [HideInInspector]
    public bool isLongJump = false; //낮은 점프, 높은 점프 체크



    //유니티 Layer의 역할(변수 타입 LayerMask) : 오브젝트가 그려지는 순서를 설정할 수 있다. 오브젝트 충돌이서 지정한 레이어와의 충돌을 제외할 수 있다.
    [SerializeField]
    private LayerMask groundLayer; //바닥 체크를 위한 충돌 레이어
    private CapsuleCollider2D capsuleCollider2D; //오브젝트의 충돌 범위 컴포넌트
    private bool isGrounded; //바닥 체크(바닥에 닿아있을 때 true)
    private Vector3 footPosition; //발의 위치

    // Start is called before the first frame update

    [SerializeField]
    int maxJumCount = 2;
    int currentJumCount = 0;
    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if (currentJumCount > 0)
        {
            rigid2D.velocity = Vector2.up * jumpForce;

            currentJumCount--;
        }
    }

    void FixedUpdate()
    {

        //플레이어 오브젝트의 collider2D min, center, max 위치 정보
        //00Collider2D.bounds : 충돌 범위의 min, center, max 위치 값. 2d일 때는 Vector2, 3d일 때는 Vector3

        Bounds bounds = capsuleCollider2D.bounds;
        //플레이어의 발 위치 설정
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        //Collider2D collider = Physics2D.OverlapCircle(Vector2 position, float radius, LayerMask layer)
        //position 위치에 radius 반지름 크기의 보이지 않는 '원 충돌 범위'를 생성한다. 원에 충돌하는 오브젝트(레이어가 layer이어야 한다)의 Collider2D 컴포넌트를 저장한다.
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if (isGrounded == true && rigid2D.velocity.y <= 0)
        {
            currentJumCount = maxJumCount;
        }


        //중력 계수 : 플레이어에게 가해지는 중력은 (0, -9.81, 0) * gravityScale
        //grivityScale이 1이면 trasform.position += (0, -9.81, 0)의 연산이 추가되고, 2.5면 += (0, -24.525,0)의 연산이 추가된다.

        //낮은 점프, 높은 점프 구현을 위한 중력 계수(gravityScale)를 조절한다.(Jump Up 일때만 적용)
        //중력 계수가 낮은 if문은 높은 점프, 중력 계수가 높은 else 문은 낮은 점프
        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }
    }

    private void OnDrawGizmos()
    {
        //화면에 보이지 않는 충돌 범위와 같은 것들을 내가 원하는 위치에 잘 배치했는지를 확인하고 싶을 때 선, 사각형, 원 등을 그려서 확인하는 용도이다.
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition, 0.1f);
        //.Drawline, .DrawCube.. 등 이용 가능
    }
}
