using UnityEngine;

public class PlayerController_2 : MonoBehaviour
{
    private Movement2D_3 movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D_3>();
    }

    private void Update()
    {
        // left or a = -1 / right or d = 1
        float x = Input.GetAxisRaw("Horizontal");
        // 좌우 이동 방향 제어
        movement2D.Move(x);

        // 스페이스바 누르면 플레이어 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement2D.Jump();
        }

        // 스페이스 바 누르고 있으면 isLongJump = true
        if (Input.GetKey(KeyCode.Space))
        {
            movement2D.isLongJump = true; 
        }
        // 스페이스 바를 떼면 isLongJump = false
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            movement2D.isLongJump = false;
        }
    }
}
