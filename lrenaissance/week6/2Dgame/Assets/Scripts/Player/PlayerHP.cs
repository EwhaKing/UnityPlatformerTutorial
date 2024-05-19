using System.Collections;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private UIPlayerData uiPlayerData;
    [SerializeField]
    private int max = 3; //최대 체력
    [SerializeField]
    private int current; //현재 체력

    private SpriteRenderer spriteRenderer; //플레이어 피격 시 색상 변경
    private Color originColor; //플레이어 초기 색상

    [SerializeField]
    private float invincibilityTime = 0; //무적 시간
    private bool isInvincibility = false; //무적 여부

    private void Awake()
    {
        current = max;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originColor=spriteRenderer.color;
    }

    public void DecreaseHP()
    {
        if (isInvincibility) return; //무적 상태일 때는 체력 감소x

        OnInvincibility(1);//체력 감소하면 일정시간 동안 무적 상태

        if(current>1)
        {
            current--;
            uiPlayerData.SetHP(current, false);
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
            uiPlayerData.SetHP(current, true);
            current++;
        }
    }

    public void OnInvincibility(float time)
    {
        if (isInvincibility)//이미 무적이면
        {
            invincibilityTime+= time;//무적 시간 증가
        }
        else
        {
            invincibilityTime = time;
            StartCoroutine(nameof(Invincibility));//무적 상태 불러오기
        }
    }

    private IEnumerator Invincibility()
    {
        isInvincibility=true;

        float blinkSpeed = 10;

        while(invincibilityTime>0)
        {
            invincibilityTime -= Time.deltaTime;

            Color color = spriteRenderer.color;
            color.a = Mathf.SmoothStep(0, 1, Mathf.PingPong(Time.time * blinkSpeed, 1));//SmoothStep 이용해 깜박거림(알파값이 0-1 왕복)
            spriteRenderer.color = color;

            yield return null;
        }

        //무적 상태 끝
        spriteRenderer.color = originColor;
        isInvincibility = false;
    }
}
