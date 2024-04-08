using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;

    private void Awake()
    {
        //Destroy(): ������Ʈ ���� �Լ�. �Ű������� �ԷµǾ� �ִ� obj�� cmp ����
        //playerObj(���� ������Ʈ)�� "PlayerCtrl" ������Ʈ ����
        Destroy(playerObj.GetComponent<PlayerCtrl>());

        //���� obj ����
        //Destroy(playerObj);

        //2�� �ڿ� obj ����
        Destroy(playerObj, 2.0f);
    }
}
