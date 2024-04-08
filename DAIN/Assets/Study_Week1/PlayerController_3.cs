using UnityEngine;

public class PlayerController_3 : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("isDie"); // parameter�� �����Ͽ� �� ���� ����
            // isDie�� ���� boolean �̱� ������ üũ(true)�ϰ� ��
        }
    }

    // public���� ���־�� Animation���� �� �Լ��� ȣ���� �� ����
    public void onDieEvent()
    {
        Debug.Log("End of Die Animation");
    }
}
