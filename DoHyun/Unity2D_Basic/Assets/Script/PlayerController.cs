using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private KeyCode keyCodeFire = KeyCode.Space;
    [SerializeField]
    private GameObject bulletPrefab;
    private float moveSpeed = 3.0f;

    //총알의 움직임을 위해 마지막에 움직였던 방향을 저장한다.
    private Vector3 lastMoveDirection = Vector3.right; //최초에는 오른쪽으로 발사되게 설정


    private void Update()
    {
        //플레이어 오브젝트의 이동(직접 작성해보기)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //새로운 위치 = 현재 위치 + (방향 * 속도)
        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;


        //마지막에 입력된 방향키의 방향을 총알의 발사 방향으로 활용한다. 키가 눌리지 않은 경우 = 정지한 경우에는 총알 발사 병향으로 활용하면 안됨
        if (x != 0 || y != 0)
        {
            lastMoveDirection = new Vector3(x, y, 0);
        }


        //플레이어의 총알 발사(직접 작성해보기)
        if (Input.GetKeyDown(keyCodeFire))
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;
            clone.GetComponent<Movement2D_2>().Setup(lastMoveDirection);
        }
    }
}
