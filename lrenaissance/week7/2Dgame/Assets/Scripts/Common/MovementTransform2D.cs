using UnityEngine;

public class MovementTransform2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    private void Update()
    {
        //위치=현재 위치+방향*속도
        transform.position += moveDirection * moveSpeed * Time.deltaTime;        
    }
    public void MoveTo(Vector3 direction)//이동방향 설정
    {
        moveDirection = direction;
    }
}
