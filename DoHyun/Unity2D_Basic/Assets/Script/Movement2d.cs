using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2d : MonoBehaviour
{
    private float moveSpeed = 5.0f; //이동 속도
    private Vector3 moveDirection = Vector3.zero;//이동 방향
    private void Awake()
    {   //새로운 위치 = 현재 위치 + (방향 * 속도)
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        //transform.position += Vector3.right * 1;
    }
    private void Update()
    {
        //방향 * 속도 * Time.deltaTime
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1 * Time.deltaTime;
        //transform.position += Vector3.right * 1 * Time.deltaTime;


        //float value = Input.GetAxisRaw("단축키명"); -> 단축키의 값이 변수에 저장된다.
        /* 현재 horizontal 단축키에
            Negative - left, a : -1
            Positive - right, d : +1
            이렇게 등록되어 있으므로, a를 누르면 value에 -1이, right를 누르면 +1이 저장된다.
            None(아무것도 누르지 않은 경우)에는 0이 저장된다.
        */
        //GetAxixRaw()는 키를 누르면 바로 해당 값이 되지만, GetAxis()는 키를 누르고 있으면 0에서 서서히 증가한다.



        // Negative - left, a : -1
        // Positive - right, d : +1
        // None : 0
        float x = Input.GetAxisRaw("Horizontal");
        // Negative - down, s : -1
        // Positive - up, w : +1
        // None : 0
        float y = Input.GetAxisRaw("Vertical");

        //키를 누르면 이동 방향을 설정해준다.
        moveDirection = new Vector3(x, y, 0);


        //새로운 위치
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }
}
