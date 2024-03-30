using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] //변수 바로 윗줄에 작성. Inspector View에서 변수의 옵션을 조절할 수 있게 함
    private Color color;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //두 오브젝트가 충돌하는 순간 1회 호출
        spriteRenderer.color = color;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //충돌 직후 맞닿아 있는 동안 매 프레임 호출
        Debug.Log(gameObject.name + ": OnCollisionStay2D() executed");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //두 obj가 떨어져서 충돌 종료되는 순간 1회 호출
        spriteRenderer.color = Color.white;
    }
}
