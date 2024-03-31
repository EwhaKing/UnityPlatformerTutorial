using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    //내가 소속된 게임오브젝트의 컴포넌트 정보 GetComponent<컴포넌트>()
    //내가 아닌 다른 게임오브젝트의 컴포넌트 정보 게임오브젝트.GetComponent<컴포넌트>()
    //다른 게임오브젝트의 정보는 코드와 같이 미리 변수 만들어서 게임오브젝트 정보를 저장해두고 사용 or 유니티에서 제공하는 함수 이용해 탐색

    [SerializeField]
    private GameObject moveObject;
    [SerializeField]
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = 5.0f;
    }

    /// <summary> 충돌이 일어나는 순간 1회 호출
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //moveObject 오브젝트의 색상을 검은색으로 설정
        moveObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    /// <summary> 충돌이 유지되는 동안 매 프레임 호출
    private void OnTriggerStay2D(Collider2D collision)
    {
        //moveObject 오브젝트를 moveDirection 방향으로 이동한다
        moveObject.transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    /// <summary> 충돌이 종료되는 순간 1회 호출
    private void OnTriggerExit2D(Collider2D collision)
    {
        //moveObject 오브젝트의 색상을 흰색으로 설정한다.
        moveObject.GetComponent <SpriteRenderer>().color = Color.white;
        //moveObject 오브젝트의 위치를 (0,4,0)으로 설정한다.
        moveObject.transform.position = new Vector3(0, 4, 0); 
    }
}
