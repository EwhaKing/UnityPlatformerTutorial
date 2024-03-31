using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f; // 이동 속도
    private Rigidbody2D rigid2D;

   private void Awake(){
    rigid2D = GetComponent<Rigidbody2D>(); // 게임 오브젝트의 컴포넌트에 접근하는 방법 Getcomponent<컴포넌트 이름>();
   }

     private void Update()
   {
    float x = Input.GetAxisRaw("Horizontal"); // 좌우이동
    float y = Input.GetAxisRaw("Vertical"); // 위아래 이동

    
    // transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;

    rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
   }
}

