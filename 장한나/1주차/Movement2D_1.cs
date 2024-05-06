using UnityEngine;

public class Movement2D_1 : MonoBehaviour
{
    //�浹 ����
    private float moveSpeed = 5.0f; //�̵��ӵ�
    private Rigidbody2D rigid2D; //������Ʈ�� ������ Ÿ���� ���� ����

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>(); //������Ʈ ������ ���ͼ� ������ ����
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); //�¿� �̵�
        float y = Input.GetAxisRaw("Vertical"); // ���Ʒ� �̵�

        // Rigidbody2D ������Ʈ�� �ִ� �ӷ�(velocity) ���� ����
        rigid2D.velocity = new Vector3(x, y, 0)*moveSpeed; // ������Ʈ ������ ����� ������ ���
    }
}
