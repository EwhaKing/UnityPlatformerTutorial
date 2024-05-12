using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private MovementRigidbody2D movement; //플레이어 발사체의 이동, 점프 처리 및 제어하는 클래스
    private float originSpeed; //발사체가 생성되었을 때의 최초 x 속력 저장

    //발사체를 생성할 때 호출되는 메소드
    //direction = 현재 플레이어가 바라보고 있는 방향 정보 
    public void Setup(int direction)
    {
        movement = GetComponent<MovementRigidbody2D>();
        movement.MoveTo(direction);

        originSpeed = Mathf.Abs(movement.Velocity.x); //발사체가 좌, 우로 이동할 수 있기 때문에 x 속력의 절대값을 변수에 저장
    }

    private void Update()
    {
        if (movement.IsGrounded) movement.Jump();
        if (Mathf.Abs(movement.Velocity.x) < originSpeed) //x 속력의 절대값이 처음 속력보다 줄어들었다 = 다른 오브젝트와 충돌했다
        {
            Destroy(gameObject);
        }
    }
}
