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
        // �¿� �̵� ���� ����
        movement2D.Move(x);

        // �����̽��� ������ �÷��̾� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement2D.Jump();
        }

        // �����̽� �� ������ ������ isLongJump = true
        if (Input.GetKey(KeyCode.Space))
        {
            movement2D.isLongJump = true; 
        }
        // �����̽� �ٸ� ���� isLongJump = false
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            movement2D.isLongJump = false;
        }
    }
}
