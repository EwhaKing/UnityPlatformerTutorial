using UnityEngine;

public class Movement2D_2 : MonoBehaviour
{
    private float moveSpeed = 5.0f; // 이동 속도
    private Vector3 moveDirection; // 이동 방향

    public void Setup(Vector3 direction)
    {
        moveDirection = direction;
    }

    private void Update()
    {
        // 새로운 위치 = 현재 위치 + (방향 * 속도)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}