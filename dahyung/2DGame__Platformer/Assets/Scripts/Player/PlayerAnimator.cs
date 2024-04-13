using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private MovementRigidbody2D movement;

    private void Awake() {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<MovementRigidbody2D>();
    }

    public void UpdateAnimation(float x)
    {
        if(x != 0)
        {
            SpriteFlipX(x);
        }

        animator.SetBool("isJump", !movement.IsGrounded);

        if(movement.IsGrounded){
            animator.SetFloat("velocityX", Mathf.Abs(x));
        }

        else{
            animator.SetFloat("velocityY", movement.velocity.y);
        }
    }

    private void SpriteFlipX(float x){
        transform.parent.localScale = new Vector3((x < 0 ? -1 : 1), 1, 1);
    }
}
