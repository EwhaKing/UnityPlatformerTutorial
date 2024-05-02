using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

//페이드 효과는 게임 전반에 걸쳐 범용적으로 사용하기 때문에 정적 클래스, 메소드를 정의해 인스턴스 변수를 생성하지 않고 바로 호출할 수 있도록 함
public static class FadeEffect
{
    public static IEnumerator Fade(Tilemap target, float start, float end, float fadeTime = 1, UnityAction action = null)
    {
        //페이드 효과를 재생할 대상(target)이 없으면 코루틴 메소드 종료
        if (target == null) yield break;

        float percent = 0;

        while (percent < 1)
        {
            //페이드 효과 재생

            percent += Time.deltaTime / fadeTime;
            Color color = target.color; //현재 색상 정보 저장
            color.a = Mathf.Lerp(start, end, percent);//색상의 alpha 값 변경
            target.color = color;//변경된 색상 반영

            yield return null;
        }

        //페이드 효과 재생이 완료되면 action 메소드가 등록되어 있는지를 확인한다.
        //등록되어 있다면 해당 메소드를 실행한다.
        action?.Invoke();

    }
}
