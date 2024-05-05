using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJump : PlatformBase
{
    [SerializeField]
    float jumpForce = 22; //발판이 플레이어에게 전달하는 점프 힘
    [SerializeField]
    float resetTime = 0.5f;//다시 밟을 수 있는 초기화 시간

    private Animator animator; //플레이어와 점프 발판이 충될했을 때 애니메이션 재생
    private GameObject other; //애니메이션의 특정 프레임에서 플레이어가 점프하기 때문에 발판을 밟은 플레이어의 정보를 지정해두기 위한 변수 선언


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public override void UpdateCollision(GameObject other)
    {
        //중복 호출을 막기 위함
        if (IsHit) return;

        IsHit = true;

        //매개변수로 받아온 플레이어 오브젝트 정보 other를 멤버변수 other에 저장한다.
        this.other = other;

        //파라미터를 활성화해 점프 애니메이션을 재생한다.
        animator.SetTrigger("onJump");

    }

    //애니메이션의 특정 프레임에 호출한다.
    public void JumpAction()
    {
        //플레이어의 JumpTo() 메소드를 호출해 jumpForce 힘으로 점프하도록 한다.
        other.GetComponent<MovementRigidbody2D>().JumpTo(jumpForce);

        //other 초기화
        other = null;

        //Invoke 메소드를 호출해 Reset() 메소드를 restTime 후에 호출
        Invoke(nameof(Reset), resetTime);
    }

    private void Reset()
    {
        IsHit = false;
    }
}
