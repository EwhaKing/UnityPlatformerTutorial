using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroom : EnemyBase
{
    private FollowPath followPath; //현재 이동방향, 상태 정보를 얻어오기 위한 followPath
    private SpriteRenderer spriteRenderer; //현재 이동방향에 따라 이미지 좌/우 반전 처리를 위한 spriteRenderer
    private Animator animator; //현재 상태에 따라 애니메이션 재생 처리를 위한 animator 변수

    public override void OnDie()
    {
        //이미 OnDie()메소드가 호출되었으면 중복 처리되지 않도록 한다.
        if (IsDie == true) return;

        IsDie = true;

        //적이 사망하기 때문에 followPath.Stop()을 호출하여 경로 따라가기를 중지한다.
        followPath.Stop();
        //사망 애니메이션 재생
        animator.SetTrigger("onDie");
    }

    private void Awake()
    {
        followPath = GetComponent<FollowPath>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //followPath.Direction이 1이면 flipX를 true로 설정, -1이면 false로 설정하여 이미지 좌/우 반전을 처리한다.
        spriteRenderer.flipX = followPath.Direction == 1 ? true : false;

        //followPath.State의 값을 정수로 변환하면 Idle일 때 0, Move일 때 1의 값을 갖는다.
        //이 값을 moveSpeed 파라미터에 적용해 대기, 이동 애니메이션을 재생한다.
        animator.SetFloat("moveSpeed", (int)followPath.State);
    }
}
