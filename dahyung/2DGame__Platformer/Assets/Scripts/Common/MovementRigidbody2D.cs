using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    [Header("LayerMask")]
    [SerializeField]
    private LayerMask groundCheckLayer; // 바닥 체크를 위한 충돌 레이어

    [Header("Move")]
    [SerializeField]
    private float walkSpeed = 5; // 걷는 속도
    [SerializeField]
    private float runSpeed = 8; // 뛰는 속도

    [Header("Jump")]
    [SerializeField]
    private float jumpForce = 13; // 점프 힘
    [SerializeField]
    private float lowGravityScale = 2; // 점프키를 오래 누르고 있을 때 작용되는 중력(높은점프)
    [SerializeField]
    private float highGravityScale = 3.5f; // 일반적으로 작용되는 중력(낮은 점프)

    private float moveSpeed; // 이동 속도

    // 바닥 착지 직전 조금 빨리 점프 키를 눌렀을 때 바닥에 착지하면 바로 점프가 되도록
    private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

    // 낭떠러지에서 떨어질 때 아주 잠시 동안 점프가 가능하도록 설정하기 위한 변수
    private float hangTime = 0.2f;
    private float hangCounter;

    private Vector2 collisionSize; // 머리, 발 위치에 생성하는 충돌 박스 크기
    private Vector2 footPosition; // 발 위치

    private Rigidbody2D rigid2D; // 물리를 제어하는 컴포넌트
    private Collider2D collider2D; // 현재 오브젝트의 충돌 범위

    public bool IsLongJump {set; get;} = false; // 낮음 점프, 높은 점프 체크
    public bool IsGrounded {private set; get;} = false; // 바닥 체크 (바닥에 닿아있을 때 true)

    public Vector2 velocity => rigid2D.velocity;

    private void Awake() {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        UpdateCollision();
        JumpHeight();
        JumpAdditive();
    }

    public void MoveTo(float x) {
        moveSpeed = Mathf.Abs(x) != 1 ? walkSpeed : runSpeed;

        if (x != 0) x = Mathf.Sign(x);

        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    private void UpdateCollision() {
        Bounds bounds = collider2D.bounds;

        collisionSize = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);

        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        IsGrounded = Physics2D.OverlapBox(footPosition, collisionSize, 0, groundCheckLayer);
    }

    public void Jump(){
        /*if(IsGrounded == true)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
        }*/
        jumpBufferCounter = jumpBufferTime;
    }

    public void JumpHeight() {
        if (IsLongJump && rigid2D.velocity.y > 0){
            rigid2D.gravityScale = lowGravityScale;
        }
        else{
            rigid2D.gravityScale = highGravityScale;  
        }
    }

    private void JumpAdditive() {
        // 낭떠러지에서 떨어질 때 아주 잠시동안은 점프가 가능하도록 설정
        if (IsGrounded) hangCounter = hangTime;
        else hangCounter -= Time.deltaTime;

        // 바닥에 착지 직전 조금 빨리 점프 키를 눌렀을 때 바닥에 착지하면 바로 점프하도록 설정
        if(jumpBufferCounter > 0) jumpBufferCounter -= Time.deltaTime;

        if(jumpBufferCounter > 0)
        {
            // 점프 힘(jumpForce)만큼 y축 방향 속력으로 설정
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
            jumpBufferCounter = 0;
            hangCounter = 0;
        }
    }
}
