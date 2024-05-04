using UnityEngine;

public class PlayerAnimator: MonoBehaviour
{
    private Animator animator;
    private MovementRigidbody2D movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<MovementRigidbody2D>();
    }

    public void UpdateAnimation(float x)
    {
        //좌우 방향키 입력 있을 때
        if (x != 0)
        {
            //플레이어 스프라이트 좌우 반전
            SpriteFlipX(x);
        }
        animator.SetBool("isJump", !movement.IsGrounded);

        //바닥에 닿아 있으면
        if(movement.IsGrounded )
        {
            //velocityX가 0이면 "Idle", 0.5이면 "Walk", 1이면 "Run"
            animator.SetFloat("velocityX", Mathf.Abs(x));
        }
        //바닥에 닿아 있지 않음
        else
        {
            //velocityY가 음수이면 "JumpDown", 양수이면 "JumpUp"
            animator.SetFloat("velocityY", movement.Velocity.y);
        }
    }

    //SpriteRenderer 컴포넌트의 Flip을 이용해 이미지를 반전했을 때 화면에 출력되는 이미지 자체만 반전되기 때문에
    //플레이어의 전방 특정 위치에서 발사체를 생성하는 것과 같이 방향전환이 필요할 때는 Transform.Scale.x를 -1과 1과 같이 설정
    private void SpriteFlipX(float x)
    {
        transform.parent.localScale=new Vector3((x<0 ?-1:1),1,1);
    }
}
