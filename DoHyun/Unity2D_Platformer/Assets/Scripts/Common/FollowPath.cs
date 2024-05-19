using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//현재 경로 따라가기의 상태를 나타내는 열거형
public enum FollowPath_State { Idle = 0, Move } //대기상태 = 0, 이동 상태 = 1
public class FollowPath : MonoBehaviour
{

    [SerializeField]
    private Transform target; //실제 이동하는 대상의 Transform
    [SerializeField]
    private Transform[] wayPoints; //이동 가능한 지점
    [SerializeField]
    private float waitTime; //wayPoints 도착 후 대기 시간. 각 구간마다 대기 시간이 다르면 waitTime도 배열로 선언해야 한다.
    [SerializeField]
    private float timeOffset; //이동시간 설정을 위한 timeOffset. 이동시간 = 거리 * timeOffset

    private int wayPointsCount; //이동 가능한 wayPoints 개수
    private int currentIndex = 0; //현재 wayPoints index



    //=====Follow Path State 삳태에 따라 follow 컨트롤을 위한 변수 추가=====//
    private int direction;
    public int Direction => direction; //외부에서 Get만 가능한 프로퍼티 정의

    public FollowPath_State State { private set; get; } = FollowPath_State.Idle; //현재 경로 따라가기의 상태를 설정하거나 확인하는 set, get이 가능한 프로퍼티 정의. 이때 상태 설정은 현재 클래스에서만 가능하도록 private로 정의한다.

    private void Awake()
    {
        target.position = wayPoints[currentIndex].position;
        wayPointsCount = wayPoints.Length;

        currentIndex++; //시작시 0 위치에 있고 그 다음 인덱스로 이동하기 위해 1 증가시킨다.
        StartCoroutine(nameof(Process));
    }


    //무한루프를 돌며 MoveAtoB() 메소드를 호출해 현재 발판 위치를 다음 이동지점까지 이동시키는 메소드
    private IEnumerator Process()
    {
        while (true)
        {
            //wayPoints[currentIndex].position 위치까지 이동
            yield return StartCoroutine(MoveAToB(target.position, wayPoints[currentIndex].position));

            //waitTime 시간 동안 대기
            yield return new WaitForSeconds(waitTime);

            //다음 이동 지점(wayPoint) 설정
            currentIndex = (currentIndex + 1) % wayPointsCount;
        }
    }

    //start에서 end위치까지 이동하는 MoveAToB() 코루틴 메소드
    private IEnumerator MoveAToB(Vector3 start, Vector3 end)
    {
        float percent = 0;
        float moveTime = Vector3.Distance(start, end) * timeOffset;

        //이동하는 while() 반복문 호출 전에 이동방향 direction 값을 설정하는 메소드 호출
        SetDirection(start.x, end.x);
        //현재 경로 따라가기 상태를 이동으로 설정
        State = FollowPath_State.Move;

        while (percent < 1)
        {
            percent += Time.deltaTime / moveTime;
            target.position = Vector3.Lerp(start, end, percent);
            yield return null;
        }

        //while() 반복문 호출이 끝나면 이동이 완료되었다는 뜻으로 현재 경로 따라가기 상태를 대기로 설정
        State = FollowPath_State.Idle;
    }

    /// <summary>
    /// 매개변수로 받아온 시작 x위치, 목표 x위치를 기준으로 현재 이동 방향을 판단하는 메소드
    /// </summary>
    /// <param name="start">시작 위치 </param>
    /// <param name="end">목표 위치</param>
    private void SetDirection(float start, float end)
    {
        //end-start 값이 0이 아니면 좌/우 방향으로 이동 중이다.
        if (end - start != 0) direction = (int)Mathf.Sign(end - start); //음수면 -1, 양수면 1을 변수에 저장한다.
        else direction = 0;
    }


    /// <summary>
    /// 외부에서 경로 따라가기를 중지할 때 호출하는 Stop() 메소드
    /// </summary>
    public void Stop()
    {
        StopAllCoroutines(); // 현재 클래스에서 재생중인 모든 코루틴 중지
    }
}
