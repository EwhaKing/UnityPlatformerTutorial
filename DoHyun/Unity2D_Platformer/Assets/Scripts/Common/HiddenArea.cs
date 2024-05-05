using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenArea : MonoBehaviour
{
    private Tilemap tilemap;
    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Hidden Tilemap 오브젝트와 충돌한 오브젝트의 태그가 Player인지 확인

            //페이드 효과 재생
            //페이드 효과가 재생되는 도중에 충돌 시작, 충돌 해제를 반복할 수 있게 때문에 
            //현재 재생중인 코루틴을 중지 & 알파 값 감소하는 페이드 효과 재생
            StopAllCoroutines();
            StartCoroutine(FadeEffect.Fade(tilemap, tilemap.color.a, 0, tilemap.color.a));

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(FadeEffect.Fade(tilemap, tilemap.color.a, 1, 1 - tilemap.color.a));
        }
    }
}
