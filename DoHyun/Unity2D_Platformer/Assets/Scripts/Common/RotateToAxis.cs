using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//특정 축을 기준으로 회전을 제어
public class RotateToAxis : MonoBehaviour
{
    [SerializeField]
    private Transform target; //회전하는 대상
    [SerializeField]
    private Vector3 axis = Vector3.forward; //2d는 일반적으로 z축만 회전하기 때문에 Vector3.forward를 기본 값으로 사용한다.
    [SerializeField]
    private float rotateSpeed = 200; //회전 속도


    private void Update()
    {
        target.Rotate(axis, rotateSpeed * Time.deltaTime); //axis 축으로 1초에 rotatespeed만틈 회전
    }
}
