using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    //충돌 이벤트 함수

    [SerializeField]
    //해당 변수 바로 윗줄에 작성, Inspector View에서 변수의 옵션을 조절할 수 있게 해줌
    //여기선 private Color color;의 것
    private Color color;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary> 충돌이 일어나는 순간 1회 호출 
    private void OnCollisionEnter2D(Collision2D collision) //현재 컴포넌트를 가지고 있는 오브젝트에 부딪힌 오브젝트 정보
    {
        spriteRenderer.color = color;
    }

    /// <summary> 충돌이 유지되는 동안 매 프레임 호출
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + "OnCollisionStay2D() 메소드 실행");
    }

    /// <summary> 충돌이 종료되는 순간 1회 호출
    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.color = Color.white;
    }
}
