using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPressAnyKey;
    [SerializeField]
    private float textBlinkTime = 0.5f;
    [SerializeField]
    private Image imageFadeScreen;

    private bool isKeyDown = false;

    private IEnumerator Start()
    {
        while (true)
        {
            //알파값 1에서 0으로 textBlinkTime동안
            yield return StartCoroutine(FadeEffect.Fade(textPressAnyKey, 1, 0, textBlinkTime));
            yield return StartCoroutine(FadeEffect.Fade(textPressAnyKey, 0, 1, textBlinkTime));
        }
    }

    private void Update()
    {
        if (isKeyDown == true)
        {
            return;
        }
        if (Input.anyKeyDown)
        {
            isKeyDown = true;
            //imageFadeScreen의 알파값 0에서 1까지 1초 동안 재생
            StartCoroutine(FadeEffect.Fade(imageFadeScreen, 0, 1, 1, AfterFadeEffect));
        }
    }

    private void AfterFadeEffect()//selectLevel scene load
    {
        Utils.LoadScene(SceneNames.SelectLevel);
    }
}
