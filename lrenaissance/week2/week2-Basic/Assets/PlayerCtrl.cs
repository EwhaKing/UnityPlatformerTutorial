using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour //총 발사
{
    [SerializeField]
    private KeyCode keyCodeFire=KeyCode.Space;//스페이스바
    [SerializeField]
    private GameObject bulletPrefab;
    private float moveSpeed = 3.0f;
    private Vector3 lastMoveDir = Vector3.right;//마지막에 움직였던 방향 저장

    private void Update()
    {
        //player obj 이동
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;

        if(x!=0 || y != 0)//마지막에 입력된 방향키의 방향을 총알의 발사 방향으로 활용
        {
            lastMoveDir=new Vector3(x,y,0);
        }

        //player obj 총알 발사
        if(Input.GetKeyDown(keyCodeFire)) //스페이스바 누르면 실행
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;

            clone.GetComponent<Movement2D>().Setup(lastMoveDir);//방향값 전달
        }
    }
}
