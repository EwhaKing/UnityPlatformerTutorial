using System.Collections;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    private Transform target; //���� �̵��ϴ� ����� Transform
    [SerializeField]
    private Transform[] wayPoints; //�̵� ������ ����
    [SerializeField]
    private float waitTime; // wayPoint ���� �� ���ð�
    [SerializeField]
    private float timeOffset; // �̵��ð� = �Ÿ� * timeOffset

    private int wayPointCount; // �̵� ������ wayPoint ����
    private int currentIndex = 0;   // ���� wayPoint �ε���


    private void Awake()
    {
        target.position = wayPoints[currentIndex].position;
        wayPointCount = wayPoints.Length;

        currentIndex++;

        StartCoroutine(nameof(Process));
    }
    private IEnumerator Process()
    {
        while (true)
        {
            //wayPoints[currentIndex].position ��ġ���� �̵�
            yield return StartCoroutine(MoveAToB(target.position, wayPoints[currentIndex].position));

            //waitTime �ð� ���� ���
            yield return new WaitForSeconds(waitTime);

            //���� �̵� ����(wayPoint) ����
            if (currentIndex < wayPointCount - 1) currentIndex++;
            else currentIndex = 0;
        }
    }
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
