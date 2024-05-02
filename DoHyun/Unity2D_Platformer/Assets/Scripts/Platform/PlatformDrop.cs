using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RespawnType { AfterTime = 0, PlayerDead }
public class PlatformDrop : PlatformBase
{
    [SerializeField]
    private RespawnType respawnType = RespawnType.AfterTime; //발판의 재생성 여부를 결정
    [SerializeField]
    private float respawnTime = 2; //재생성 or 삭제 시간

    //발판 충돌 활성 / 비활성 설정을 위한 변수
    private BoxCollider2D boxCollider2D;
    //kinematic 설정으로 물리 활성/ 비활성 설정을 위한 변수
    private Rigidbody2D rigid2D;
    //발판 재생성을 위한 발판 초기 위치 저장하는 변수
    private Vector3 originPosition;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigid2D = GetComponent<Rigidbody2D>();
        originPosition = transform.position;
    }

    public override void UpdateCollision(GameObject other)
    {
        //짧은 시간 내에 충돌 처리가 여러번 되지 않도록 처리
        if (IsHit) return;

        IsHit = true;

        StartCoroutine(nameof(Process));

    }

    //플레이어와 발판이 충돌했을 때의 전체 로직을 실행하는 메소드
    IEnumerator Process()
    {
        //1. 발판이 흔들리는 애니메이션 재생 - OnShake() 코루틴 메소드를 호출
        yield return StartCoroutine(nameof(OnShake));
        //2. 발판 삭제(아래로 추락)
        OnDrop();


        //3. 재생성 가능한 발판이면 일정 시간 후 발판 재생성=원래 위치로 가져다두기 / 아니면 일정 시간 후 오브젝트 삭제
        if (respawnType == RespawnType.AfterTime)
        {
            StartCoroutine(nameof(OnRespawn));
        }
        else
        {
            Destroy(gameObject, respawnTime);
        }

    }


    IEnumerator OnShake()
    {
        //발판의 x축을 -5~5초 각도로 1.5초 동안 회전해 흔들거리는 것처럼 보이게 한다.

        float percent = 0;
        float shakeAngle = 5;
        float shakeSpeed = 10;
        float shakeTime = 1.5f;

        while (percent < 1)
        {
            percent += Time.deltaTime / shakeTime;
            //Mathf.PingPong()을 호출해서 0~1 시아의 값을 순회하도록 한다.
            //Mathf.PingPong(float value, float max) : 0~max 사이의 값을 반환한다. value가 max보다 큰 경우 남아있는 값을 +- 연산해서 반환한 값을 계산한다.
            float z = Mathf.Lerp(-shakeAngle, shakeAngle, Mathf.PingPong(Time.time * shakeSpeed, 1));
            transform.rotation = Quaternion.Euler(0, 0, z);

            yield return null;
        }

        //반복문 종료되면 각도를 다시 (0,0,0)으로 설정한다.
        transform.rotation = Quaternion.identity;

    }

    IEnumerator OnRespawn()
    {
        //respawn 시간동안 대기
        yield return new WaitForSeconds(respawnTime);

        IsHit = false;
        transform.position = originPosition;

        //BoxCollider2D 활성화
        boxCollider2D.enabled = true;
        //발판이 중력의 영향을 받지 않도록 처리
        rigid2D.isKinematic = true;
        //속도도 멈춰야함!!
        rigid2D.velocity = Vector3.zero;

    }

    void OnDrop()
    {
        //발판의 충돌이 불가능하도록 Boxcollider2D 컴포넌트를 비활성화한다.
        boxCollider2D.enabled = false;
        //발판이 중력의 영향을 받아 아래로 추락하도록 설정한다.
        rigid2D.isKinematic = false;

    }

}
