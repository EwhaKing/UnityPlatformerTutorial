using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject moveObject;
    [SerializeField]
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = 5.0f;
    }

    //물리적 충돌 없이 이벤트 함수가 호출
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //두 obj 충돌시 1회 호출
        //moveObj의 색상을 검은색으로
        moveObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //충돌 직후 맞닿아 있는 동안 매 프레임 호출
        //moveObj를 moveDir 방향으로 이동
        moveObject.transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //두 obj가 떨어져서 충돌 종료시 1회 호출
        //moveObj의 색상을 흰색으로
        moveObject.GetComponent<SpriteRenderer>().color = Color.white;
        //moveObj의 위치를 (0,4,0)으로 설정
        moveObject.transform.position = new Vector3(0, 4, 0);
    }
}
