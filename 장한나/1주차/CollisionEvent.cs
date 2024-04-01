using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    //�浹 �̺�Ʈ �Լ�

    [SerializeField]
    //�ش� ���� �ٷ� ���ٿ� �ۼ�, Inspector View���� ������ �ɼ��� ������ �� �ְ� ����
    //���⼱ private Color color;�� ��
    private Color color;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary> �浹�� �Ͼ�� ���� 1ȸ ȣ�� 
    private void OnCollisionEnter2D(Collision2D collision) //���� ������Ʈ�� ������ �ִ� ������Ʈ�� �ε��� ������Ʈ ����
    {
        spriteRenderer.color = color;
    }

    /// <summary> �浹�� �����Ǵ� ���� �� ������ ȣ��
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + "OnCollisionStay2D() �޼ҵ� ����");
    }

    /// <summary> �浹�� ����Ǵ� ���� 1ȸ ȣ��
    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.color = Color.white;
    }
}
