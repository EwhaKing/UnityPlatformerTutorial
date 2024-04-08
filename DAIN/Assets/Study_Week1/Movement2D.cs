using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f; // 이동 속도
    private Vector3 moveDirection = Vector3.zero; // 이동 방향
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        // 클래스 내부 어디에서든 rigid2D 변수를 이용해 Rigidody2D 컴포넌트 정보를 바꾸거나 얻어올 수 있음
    }

    private void Update()
    {
        // Negative left, a : -1
        // Positive right, d : 1
        // Non : 0
        float x = Input.GetAxisRaw("Horizontal"); // 좌우 이동
        // Negative down, s : -1
        // Positive up, w : 1
        // Non : 0
        float y = Input.GetAxisRaw("Vertical"); // 위아래 이동

        // 이동 방향 설정
        moveDirection = new Vector3(x, y, 0);

        // 새로운 위치 = 현재 위치 + (방향 x 속도)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 이동거리 = 방향 * 속도 * Time.deltaTime
        // Time.deltaTime : 컴퓨터 사양 차이가 나서 곱해주는 게 좋음


        // 오른쪽으로 계속 이동 (아래 2줄 같은 코드임)
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        //transform.position += Vector3.right * 1 * Time.deltaTime;

        // Rigidbody2D 컴포넌트에 있는 속력 변수 설정
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;   


    }
}
