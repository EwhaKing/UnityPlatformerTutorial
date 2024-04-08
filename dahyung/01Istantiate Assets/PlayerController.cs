using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCodeFire = KeyCode.Space;
    [SerializeField]
    private GameObject bulletPrefab;
    private float moveSpeed = 3.0f;
    private Vector3 lastMoveDirection = Vector3.right;

    private void Update()
    { 
        // 플레이어 오브젝트 이동
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;

        // 마지막에 입력된 방향키의 방향을 총알의 발사 방향으로 활용
        if ( x != 0 || y != 0)
        {
            lastMoveDirection = new Vector3(x, y, 0);
        }

        // 플레이어 오브젝트 총알 발사
        if ( Input.GetKeyDown(keyCodeFire) )
        // Input.GetKeyDown(Key): 키보드의 Key 버튼을 눌렀을 때 1회 호출
        // Input.GetKeyUp(Key): 키보드의 Key 버튼을 누르고 있는 동안 메 프레임 호출
        // Input.GetKeyUp(Key): 키보드의 key 버튼을 눌렀다가 땔 때 1회 호출
        // Key의 자리에 들어가는 매개변수는 KeyCode 열거형
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;

            clone.GetComponent<Movement2D>().Setup(lastMoveDirection);
        }
    }
}
