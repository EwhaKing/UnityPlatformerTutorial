using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject moveObject;
    [SerializeField]
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = 5.0f;
    }


    // ������ �浹 X

    // OnTriggerEnter2D() : �浹�� �Ͼ�� ���� 1ȸ ȣ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    // OnTriggerStay2D() : �浹�� �����Ǵ� ���� �� ������ ȣ��
    private void OnTriggerStay2D(Collider2D collision)
    {
        moveObject.transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    // OnTriggerExit2D() : �浹�� ����Ǵ� ���� 1ȸ ȣ��
    private void OnTriggerExit2D(Collider2D collision)
    {
        // moveObject ������Ʈ�� ������ ������� ����
        moveObject.GetComponent <SpriteRenderer>().color = Color.white;
        // moveObject ������Ʈ�� ��ġ�� (0, 4, 0)���� ����
        moveObject.transform.position = new Vector3(0, 4, 0);
    }
}
