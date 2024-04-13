using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField]
    StageData stageData; //카메라의 최소, 최대 범위가 저장되어 있는 StageData 타입 변수
    [SerializeField]
    Transform target; //카메라가 추적할 대상


    //카메라가 target의 좌표와 완전히 동일하게 설정되는 것이 아닌
    //원하는 축만 추적할 수 있도록 한다.
    [SerializeField]
    bool x, y, z;

    float offsetY; //target과 카메라의 y 거리 값을 저장하는 변수


    private void Awake()
    {
        //offsetY 값 설정
        //target과 카메라의 y 거리 = |(카메라의 y 위치) - (tartget의 y 위치)|
        offsetY = Mathf.Abs(transform.position.y - target.position.y);
    }

    private void LateUpdate()
    {
        //true 축만 target의 좌표를 따라가도록 한다.
        //카메라의 위치는 x,y,z 각각 true면 target의 위치로, false면 카메라 위치 그대로
        //단 y 축은 target + offsetY
        transform.position = new Vector3(x ? target.position.x : transform.position.x, y ? target.position.y + offsetY : transform.position.y, z ? target.position.z : transform.position.z);


        //카메라의 좌/우측 이동 범위를 넘어가지 않도록 설정한다.
        //Mathf.Clamp() 메소드 함수를 사용해 CarmeraLimitMinX <= x <= CaremeraLimitMaxX가 되도록 한다.
        //Mathf.Clamp(float value, float min, float max) : value 값이 mim ,max를 넘어가는 경우 min, max 반환. 아닌 경우 value 반환
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(transform.position.x, stageData.CameraLimitMixX, stageData.CameraLimitMaxX);
        transform.position = position;
    }
}
