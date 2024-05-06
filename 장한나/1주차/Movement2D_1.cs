using UnityEngine;

public class Movement2D_1 : MonoBehaviour
{
    //충돌 관리
    private float moveSpeed = 5.0f; //이동속도
    private Rigidbody2D rigid2D; //컴포넌트와 동일한 타입의 변수 생성

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>(); //컴포넌트 정보를 얻어와서 변수에 저장
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); //좌우 이동
        float y = Input.GetAxisRaw("Vertical"); // 위아래 이동

        // Rigidbody2D 컴포넌트에 있는 속력(velocity) 변수 설정
        rigid2D.velocity = new Vector3(x, y, 0)*moveSpeed; // 컴포넌트 정보가 저장된 변수를 사용
    }
}
