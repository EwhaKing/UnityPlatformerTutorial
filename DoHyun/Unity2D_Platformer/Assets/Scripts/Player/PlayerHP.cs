using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private UIPlayerData uIPlayerData;
    [SerializeField]
    private int max = 3;//최대 체력
    [SerializeField]
    private int current; //현재 체력

    //====무적 상태====//
    private SpriteRenderer spriteRenderer; //플레이어 피격 시 색상의 알파 값 변경을 위함
    private Color originColor; //플레이어 초기 색상 정보 저장
    private float invincibilityTime = 0; //무적 지속시간
    private bool isInvinclibility = false; //무적 여부

    private void Awake()
    {
        current = max;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originColor = spriteRenderer.color;
    }

    public void DecreseHP()
    {
        //무적 상태일 때는 체력 감소 안됨
        if (isInvinclibility == true) return;

        //체력이 감소하면 일정시간 동안 무적 상태
        OnInvincibility(1);

        if (current > 1)
        {
            current--;
            uIPlayerData.SetHP(current, false);
        }
        else
        {
            Debug.Log("플레이어 사망 처리");
        }
    }

    public void IncreaseHP()
    {
        if (current < max)
        {
            uIPlayerData.SetHP(current, true);
            current++;

        }

    }

    public void OnInvincibility(float time)
    {
        if (isInvinclibility == true)
        {
            invincibilityTime += time;
        }
        else
        {
            invincibilityTime = time;
            StartCoroutine(nameof(Invincibility));
        }
    }


    //무적 시간 동안 플레이어가 깜빡거리도록 한다.
    private IEnumerator Invincibility()
    {

        isInvinclibility = true; //플레이어 무적상태로 설정
        float blinkSpeed = 10; //깜박거리는 속도

        while (invincibilityTime > 0)
        {
            invincibilityTime -= Time.deltaTime; //invincibilityTime에 설정된 시간만큼 반복문 내부를 실행하게 된다.

            Color color = spriteRenderer.color;
            //float result = Mathf.SmoothStep(float start, float end, float t);
            //Mathf.Lerp()와 유사하지만 start, end 사이의 보간 값을 결정하는 방식이 조금 다르다.
            //t가 0.0에서 1.0으로 점진적으로 증가한다고 했을 때 Mathf.Lerp()는 t값에 비례해 값이 점진적으로 변하는 반면(liner하게 증가)
            //Mathf.SmoothStep()은 t값이 커짐에 따라 값의 증가폭이 상승하고, t 값이 1에 가까워지면 값의 증가폭이 감소하는 형대로 바뀐다.

            //Mathf.PingPong(Time.time * blinkSpeed, 1)은 Time.time * blinkSpeed의 값을 0부터 1까지 반복하도록 만든다.
            //즉, 시간이 점진적으로 증가하다가 1에 도달하면 다시 0부터 시작하여 반복된다.
            color.a = Mathf.SmoothStep(0, 1, Mathf.PingPong(Time.time * blinkSpeed, 1));
            spriteRenderer.color = color;
            yield return null;
        }

        spriteRenderer.color = originColor;
        isInvinclibility = false;
    }
}
