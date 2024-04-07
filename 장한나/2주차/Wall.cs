using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //벽에 부딪힌 오브젝트를 삭제
        Destroy(collision.gameObject);

        //충돌이 일어나면 벽의 색상을 잠깐 변경한다
        StartCoroutine("HitAnimation");
    }

    private IEnumerator HitAnimation()
    {
        SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        SpriteRenderer.color = Color.white; 
    }

}
