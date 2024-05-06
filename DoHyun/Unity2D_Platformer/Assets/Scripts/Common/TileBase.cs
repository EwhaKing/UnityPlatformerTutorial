using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    //타일의 Bounce 여부는 Inspector View에서 설정할 수 있도록 한다.
    [SerializeField]
    private bool canBounce; //Bounce 가능 여부 (타일마다 다르게 적용)

    private float startPositionY; //타일의 최초 y 위치


    //타일과 플레이어가 충돌했는지를 체크한다.(일정시간 동안 다시 충돌이 처리되지 않도록 하기위함)
    public bool IsHit { private set; get; } = false;


    private void Awake()
    {
        //타일의 시작 위치를 저장
        startPositionY = transform.position.y;
    }

    //가상 메소드
    //TileBase를 상속받는 자식 클래스에서 override해서 사용하거나 TileBase의 UpdateCollision()을 호출할 수 있다.
    public virtual void UpdateCollision()
    {
        //bounce가 가능한 타일인지 체크
        if (canBounce)
        {
            IsHit = true;
            StartCoroutine(nameof(OnBounce));
        }
    }

    //타일이 충돌해 Bounce되는 최대 높이 maxBounceAmount 변수를 선언한다.
    private IEnumerator OnBounce()
    {

        float maxBounceAmount = 0.35f; //타일이 충돌해 올라가는 최대 높이

        //올라가기
        yield return StartCoroutine(MoveToY(startPositionY, startPositionY + maxBounceAmount));

        //내려오기
        yield return StartCoroutine(MoveToY(startPositionY + maxBounceAmount, startPositionY));

        //IsHit 초기화
        IsHit = false;
    }



    //코루틴 메소드. 매개변수로 받아온 start에서 end까지 y축 이동을 한다.
    IEnumerator MoveToY(float start, float end)
    {
        //코루틴 재생을 위한 percent 변수, bounceTime 변수를 선언한다.
        float percent = 0;
        float bounceTime = 0.2f;

        //percent가 1이 되면 반복문 종료
        while (percent < 1)
        {
            //percent값을 Time.deltaTime/bounceTime 만큼 증가시킴.
            //bounceTime에 설정된 시간만큼 while 반복문이 실행된다.
            percent += Time.deltaTime / bounceTime;

            Vector3 position = transform.position;
            position.y = Mathf.Lerp(start, end, percent); //Mathf.Lerp(float start, float end, float t) : 두 값 사이에 있는 특정 값에 대한 '보간 메소드'. start를 0, end를 1이라고 할 때 't 위치의 float 값을 구하는 메소드'.
            transform.position = position;

            yield return null;
        }
    }


}
