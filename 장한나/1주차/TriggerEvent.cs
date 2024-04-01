using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    //���� �Ҽӵ� ���ӿ�����Ʈ�� ������Ʈ ���� GetComponent<������Ʈ>()
    //���� �ƴ� �ٸ� ���ӿ�����Ʈ�� ������Ʈ ���� ���ӿ�����Ʈ.GetComponent<������Ʈ>()
    //�ٸ� ���ӿ�����Ʈ�� ������ �ڵ�� ���� �̸� ���� ���� ���ӿ�����Ʈ ������ �����صΰ� ��� or ����Ƽ���� �����ϴ� �Լ� �̿��� Ž��

    [SerializeField]
    private GameObject moveObject;
    [SerializeField]
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = 5.0f;
    }

    /// <summary> �浹�� �Ͼ�� ���� 1ȸ ȣ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //moveObject ������Ʈ�� ������ ���������� ����
        moveObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    /// <summary> �浹�� �����Ǵ� ���� �� ������ ȣ��
    private void OnTriggerStay2D(Collider2D collision)
    {
        //moveObject ������Ʈ�� moveDirection �������� �̵��Ѵ�
        moveObject.transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    /// <summary> �浹�� ����Ǵ� ���� 1ȸ ȣ��
    private void OnTriggerExit2D(Collider2D collision)
    {
        //moveObject ������Ʈ�� ������ ������� �����Ѵ�.
        moveObject.GetComponent <SpriteRenderer>().color = Color.white;
        //moveObject ������Ʈ�� ��ġ�� (0,4,0)���� �����Ѵ�.
        moveObject.transform.position = new Vector3(0, 4, 0); 
    }
}
