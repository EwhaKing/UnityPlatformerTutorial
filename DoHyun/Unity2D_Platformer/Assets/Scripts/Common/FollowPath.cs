using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        while (percent < 1)
        {
            percent += Time.deltaTime / moveTime;
            target.position = Vector3.Lerp(start, end, percent);
            yield return null;
        }
    }
}
