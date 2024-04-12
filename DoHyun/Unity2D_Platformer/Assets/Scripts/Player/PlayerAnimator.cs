using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    MovementRigidbody2D movement;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<MovementRigidbody2D>();
    }


    public void UpdateAnimation(float x)
    {
        //좌/우 방향키를 입력해 매개변수 x의 값이 0이 아닐 때 SpriteFlipX() 메소드를 호출해 플레이어가 바라보는 전방 방향을 설정한다.
        if (x != 0)
        {
            SpriteFlipX(x);
        }

        //바닥을 밟고 있으면 점프 중이 아닌것이므로 isGrounded 변수를 가져와 isJump 파라미터 값을 설정한다.
        animator.SetBool("isJump", !movement.IsGrounded);

        //바닥을 밟고 있으면 걷거나/대기/뛰는 애니메이션 재생(velocityX)를 사용
        if (movement.IsGrounded)
        {
            //스프라이트 방향은 SpriteFilp()으로 설정한다.
            //그러므로 절대값을 취해 해당 값으로 걷기,대기,뛰기 상태를 판별
            animator.SetFloat("velocityX", Mathf.Abs(x));
        }
        //바닥을 밟고 있지 않으면 뛰는 애니메이션 실행
        else
        {
            animator.SetFloat("velocityY", movement.Velocity.y);
        }

    }

    //SpriteRenderer 컴포넌트의 Flip을 이용해 이미지를 반전했을 때 화면에 출력되는 이미지 자체만 반전되기 때문에
    //플레이어의 전방 특정 위치에서 발사체를 생성하는 것과 같이 '방향전환이 필요할 때'는 Transforme.Scale.x를 -1, 1과 같이 설정한다.
    void SpriteFlipX(float x)
    {
        //왼쪽 방향키를 눌러 x가 음수면 Transform.Scale.x를 -1로, 오른쪽 방향키를 눌러 x가 양수면 Transform.Scale.x를 1로 설정한다.

        transform.parent.localScale = new Vector3((x < 0 ? -1 : 1), 1, 1);

    }






}
