using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField]
    private Transform target; //���� �̵��ϴ� ������ Transform

    //���ǿ� �浹�� �÷��̾� ������Ʈ�� �θ� �������� ����(������ ������ �� ���ǰ� �Բ� �����̵��� �ϱ� ����)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(target.transform);
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
