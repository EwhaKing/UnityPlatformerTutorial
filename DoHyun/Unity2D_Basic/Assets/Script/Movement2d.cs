using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2d : MonoBehaviour
{
    private void Awake()
    {   //새로운 위치 = 현재 위치 + (방향 * 속도)
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        //transform.position += Vector3.right * 1;
    }
    private void Update()
    {
        //방향 * 속도 * Time.deltaTime
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1 * Time.deltaTime;
        transform.position += Vector3.right * 1 * Time.deltaTime;

    }
}
