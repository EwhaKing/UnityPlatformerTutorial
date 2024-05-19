using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//물리 영향을 받지 않고 오브젝트의 transform.position으로 오브젝트의 이동을 제어하는 스크립트
public class MovementTrasform2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0; //이동 속도
    [SerializeField] private Vector3 moveDirection = Vector3.zero; //이동 방향
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// direction으로 이동 방향 설정 가능
    /// </summary>
    /// <param name="direction"></param>

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
