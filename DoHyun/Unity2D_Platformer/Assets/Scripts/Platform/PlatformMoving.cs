using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    //실제 이동하는 발판, 이동가능한 지점(wayPoints)들을 자식으로 가지고 있는 부모 오브젝트에 적용하는 스크립트.
    //따라서 실제 이동하는 발판의 transform을 나타내는 변수에는 실제 이동하는 발판(자식) 오브젝트의 tranform이 들어가야 한다.

    [SerializeField]
    private Transform target; //실제 이동하는 발판의 Transform
    [SerializeField]
    private Transform[] wayPoints; //이동 가능한 지점들의 배열
    [SerializeField]
    private float waitTime; //wayPoint에 도착해 잠시 대기하는 시간. 각 구감나다 대기 시간이 다르면 waitTime도 배열로 선언해야 한다.
    [SerializeField]
    private float timeOffset; //이동시간 설정을 위한 timeOffset. 이동 시간 = 거리 * timeOffset

    private int wayPointCount; //이동 가능한 wayPoint 개수

    private int currentIndex = 0; //현재 wayPoint 순번(인덱스)


    private void Awake()
    {
        target.position = wayPoints[0].position;
        wayPointCount = wayPoints.Length;
        currentIndex++;

        StartCoroutine(nameof(Process));
    }

    //무한루프를 돌며 MoveAtoB() 메소드를 호출해 현재 발판 위치를 다음 이동지점까지 이동시키는 메소드
    IEnumerator Process()
    {

        while (true)
        {
            //target.position(현재 발판 위치)에서 wayPoints[currentIndex].position(다음 이동지점) 위치까지 이동시킨다.
            yield return StartCoroutine(MoveAToB(target.position, wayPoints[currentIndex].position));

            //waitTime 시간 동안 대기
            yield return new WaitForSeconds(waitTime);

            //다음 이동 지점(wayPoint) 설정
            currentIndex = (currentIndex + 1) % wayPointCount;
        }
    }

    //start에서 end위치까지 이동하는 MoveAToB() 코루틴 메소드
    IEnumerator MoveAToB(Vector3 start, Vector3 end)
    {
        float percent = 0;
        //Vector3.Distance(Vector3 a, Vector3 b) : 두 점 a와 b 사이의 거리 값을 구해 distance에 저장
        float moveTime = Vector3.Distance(start, end) * timeOffset; //이동 시간 = 거리 * timeOffset;

        while (percent < 1)
        {
            percent += Time.deltaTime / moveTime;
            target.position = Vector3.Lerp(start, end, percent);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //발판에 충돌한 플레이어 오브젝트의 부모를 발판으로 설정하여
        //발판이 움직일 때 발판과 함께 움직이도록 한다.
        other.transform.SetParent(target.transform);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        //플레이어가 발판에서 벗어날 때 발판에 충돌한 플레이어의 오브젝트의 부모를 다시 null로 설정한다.
        other.transform.SetParent(null);
    }
}
