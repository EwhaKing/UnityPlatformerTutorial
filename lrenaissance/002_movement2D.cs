using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;//이동속도
    private Vector3 moveDirection = Vector3.zero;//이동방향

    private void Awake()
    {
        //transform은 모든 obj에 포함->소문자로 접근 가능
        //나머지 cmp GeCmp 함수 이용해서 접근
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()//Awake로 하면 한 번 움직이고 끝
    {
        //Negative lett, a -> x에 -1 저장
        //Positive right, d -> x에 1 저장
        //None: 0
        float x = Input.GetAxisRaw("Horizontal");//좌우 이동
        float y = Input.GetAxisRaw("Vertical");//위아래 이동

        //이동방향 설정
        moveDirection = new Vector3(x, y, 0);

        //transform: 내가 소속되어 있는 게임 obj의 Transform cmp
        //새로운 위치=현 위치+(방향+속도)
        //Vector3.right==Vector3(1,0,0)
        //Time.deltaTime이 1초에 Update 함수 몇번 호출되는지 결정
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1*Time.deltaTime;

        //transform.position = transform.position + moveDirection * moveSpeed * Time.deltaTime;
    
        rigid2D.velocity=new Vector3(x,y,0)*moveSpeed;
    }
}
