using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public static class FadeEffect
{
    public static IEnumerator Fade(Tilemap target, float start, float end, float fadeTime=1, UnityAction action = null)
    {
        if(target == null) yield break;

        float percent = 0;

        while(percent < 1)
        {
            percent += Time.deltaTime / fadeTime;

            Color color = target.color;
            color.a = Mathf.Lerp(start, end, percent);
            target.color = color;

            yield return null;
        }

        action?.Invoke();
    }
}
