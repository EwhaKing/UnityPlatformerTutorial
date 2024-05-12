using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBetweenAToB : MonoBehaviour
{
    [SerializeField]
    private Transform target; //회전 대상
    [SerializeField]
    private float rotateAngle = 40; //회전 각도
    [SerializeField]
    private float rotateSpeed = 2; //회전 속도

    private void Update()
    {
        //Mathf.Sine()은 각도에 따라 -1~1 사이의 값을 가진다.
        //각도 값으로 현재 시간을 나타내는 Time.time을 사용(Time.time * rotateSpeed)하기 때문에 시간이 지남에 따라 각도 값은 계속 커지고, 반환 값은 -1~1 사이로 유지된다.
        float angle = rotateAngle * Mathf.Sin(Time.time * rotateSpeed); //-40도 ~ 40도 사이의 값. target 오브젝트는 z축을 기준으로 (0,0,-40)~(0,0,40) 사이로 회전한다.
        target.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
