using System.Collections;
using UnityEngine;

public class TileBase: MonoBehaviour
{
    [SerializeField]
    private bool canBounce = false; //bounce 가능 여부
    private float startPositionY; //tile의 시작 y위치

    public bool IsHit { private set; get; } = false; //타일과 플레이어가 충돌했는지 체크(일정시간동안 다시 충돌 체크를 하지 않도록)

    private void Awake()
    {
        startPositionY=transform.position.y;
    }

    public virtual void UpdateCollision()
    {
        //Debug.Log($"{gameObject.name} 타일 충돌");

        if (canBounce==true)
        {
            IsHit = true;
            StartCoroutine(nameof(OnBounce));
        }
    }

    private IEnumerator OnBounce()
    {
        float maxBounceAmount = 0.35f;//타일 충돌해 올라가는 최대 높이

        yield return StartCoroutine(MoveToY(startPositionY,startPositionY+maxBounceAmount));

        yield return StartCoroutine(MoveToY(startPositionY + maxBounceAmount, startPositionY));

        IsHit = false;
    }

    private IEnumerator MoveToY(float start, float end)
    {
        float percent = 0;
        float bounceTime = 0.2f; //0.2초 동안 while 반복문 내부 실행

        while (percent < 1)
        {
            percent += Time.deltaTime / bounceTime;

            Vector3 position = transform.position;
            //Mathf.Lerp: 두 값 사이에 있는 특정 값에 대한 보간 메소드
            position.y = Mathf.Lerp(start, end, percent);
            transform.position= position;

            yield return null;
        }
    }
}
