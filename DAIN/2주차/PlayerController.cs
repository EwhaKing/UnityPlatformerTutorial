using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCodeFire = KeyCode.Space;
    [SerializeField]
    private GameObject bulletPrefab;
    private float movespeed = 3.0f;
    private Vector3 lastMoveDirection = Vector3.right; // 마지막에 발사됐던 방향

    private void Update()
    {
        // 플레이어 오브젝트 이동
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * movespeed * Time.deltaTime;

        // 마지막에 입력된 방향키의 방향을 총알의 발사 방향으로 활용
        if (x != 0 || y != 0) // 제자리에 있지 않는 한, 어느 방향으로 움직였든간에
        {
            lastMoveDirection = new Vector3(x, y, 0); // 움직인 방향 저장
        }


        // 플레이어 오브젝트 총알 발사 ( 슈팅 게임에 활용 가능)
        if (Input.GetKeyDown(keyCodeFire))
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // 생성한 오브젝트 정보
            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;

            // 방향 설정 (우와 신기해요)
            clone.GetComponent<Movement2D_2>().Setup(lastMoveDirection);
        }
    }
}
