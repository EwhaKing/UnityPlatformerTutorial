using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private Vector3 moveDir;

    public void Setup(Vector3 direction)
    {
        moveDir = direction;
    }
    private void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
