using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : EnemyBase
{
    [SerializeField] private LayerMask groundLayer; //적의 방향 전환을 위해 충돌 가능한 오브젝트 레이어를 설정

    private MovementRigidbody2D movement2D; //적 이동, 점프 제어
    private new Collider2D collider2D; //충돌 범위 정보은 Bounds를 얻어오기 위한 collider2D
    private Animator animator;
    private SpriteRenderer spriteRenderer; //페이드 효과 재생, 이미지 죄/우 반전을 위함
    private int direction = -1; //현재 x이동 방향 경로

    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        StartCoroutine(nameof(Idle));
    }
    public override void OnDie()
    {
        //이미 OnDie()가 호출되었으면 중복처리되지 않도록 처리
        if (IsDie == true) return;
        IsDie = true;
        //대기 또는 점프 코루틴 메소드 재생중이기 때문에 모든 재생중인 코루틴 종료한다.
        StopAllCoroutines();

        //별도의 사망 애니메이션 재생을 위한 리소스 없음.
        //Fade out 효과 재생하기
        float destroyTime = 2;
        StartCoroutine(FadeEffect.Fade(spriteRenderer, 1, 0, destroyTime));
        Destroy(gameObject, destroyTime);
    }

    /// <summary>
    /// 대기 행동에 대한 처리
    /// </summary>
    /// <returns></returns>
    private IEnumerator Idle()
    {
        float time = 0;
        float waitTime = 2;
        //time은 Time.deltaTime 만큼 증가
        //time < waitTime이면 반복문 내부 실행 -> 2초 동안 반복문을 재생한다.
        while (time < waitTime)
        {
            time += Time.deltaTime;
            yield return null;
        }
        //점프 처리
        movement2D.Jump();
        //점프 애니메이션 재생
        animator.SetTrigger("onJump");

        //점프 행동에 대한 처리 진행
        StartCoroutine(nameof(Jump));
    }


    private IEnumerator Jump()
    {
        //yield return new WaitUntil(Func<bool>)
        //Func<bool>의 결과가 true가 될때까지 대기한다.
        yield return new WaitUntil(() => !movement2D.IsGrounded);
        //WaitUntil()에 등록하는 메소드로, 프로퍼티의 반환값이 true일 때까지 대기하는 코드이다.
        //Not 연산자가 있기 때문에 movement2D.IsGrounded가 false일 때(점프해서 바닥과 떨어졌을 때) 아래 코드를 실행한다.
        //movement2D.Jump() 메소드를 호출해 y 속력이 양수가 되었지만 아직 바닥과 붙어있을 수 있기 때문에 이 코드가 없으면 아래의 조건(81줄~)을 바로 만족해 점프가 종료될 수 있다.

        while (true)
        {
            UpdateDirection();
            movement2D.MoveTo(direction);
            //현재 적의 y 속력(movement2D.Velocity.y)의 값을 velocityY 파라미터에 적용해
            //y 속력이 양수이면 JumpUp, 음수면 JumpDown 애니메이션을 재생한다.
            animator.SetFloat("velocityY", movement2D.Velocity.y);

            if (movement2D.IsGrounded) //점프했던 적 오브젝트가 바닥에 착지하면
            {
                movement2D.MoveTo(0); //제자리에 멈추도록한다.
                //착지 애니메이션
                animator.SetTrigger("onLanding");

                //대기 행동에 대한 처리를 진행하는 Idle() 코루틴 호출
                StartCoroutine(nameof(Idle));

                //Jump() 코루틴 재생 중지
                yield break;
            }
            yield return null;

        }
    }

    /// <summary>
    /// 전방에 장애물이 존재하는지 판단하는 메소드
    /// </summary>
    private void UpdateDirection()
    {
        //Bounds로 적의 충돌 범위 값을 받아와 
        Bounds bounds = collider2D.bounds;

        //전방에 생성할 충돌 박스 크기 설정
        Vector2 size = new Vector2(0.1f, (bounds.max.y - bounds.min.y) * 0.8f);

        //위치 : 현재 이동방향이 왼쪽이면 min.x, 오른쪽이면 max.x
        Vector2 position = new Vector2(direction == -1 ? bounds.min.x : bounds.max.x, bounds.center.y);

        if (Physics2D.OverlapBox(position, size, 0, groundLayer))
        {
            //장애물 존재하면 이동방향 반대로
            direction *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX; //이미지 좌우 반전
        }
    }


}
