using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)//벽 꽝
    {
        //벽에 부딪친 오브젝트 삭제
        Destroy(collision.gameObject);
        //충돌 일어나면 벽의 색상 잠깐 변경
        StartCoroutine("HitAnimation");
    }

    private IEnumerator HitAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;
    }
}
