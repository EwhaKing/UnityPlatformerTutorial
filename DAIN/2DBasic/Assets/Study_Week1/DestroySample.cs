using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private void Awake()
    {
        // playerObject ���� ������Ʈ�� "PlayerController" ������Ʈ ����
        // Destroy(playerObject.GetComponent<PlayerController>());

        // �� ó�� ������Ʈ ���� ���������� �Ʒ�ó�� �������� ���δ� �� ������
        playerObject.GetComponent<PlayerController>().enabled = false;

        // playerObject ���� ������Ʈ ����
        // Destroy(playerObject);

        // playerObject ���� ������Ʈ�� 2�� �ڿ� ����
        Destroy(playerObject, 2.0f);
    }
}
