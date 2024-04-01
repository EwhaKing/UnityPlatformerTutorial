using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //���ӿ�����Ʈ ���� �Լ� : Instantiate
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        //1. Instantiate(����������Ʈ);
        Instantiate(boxPrefab);

        //2. Instantiate(����������Ʈ, ��ġ, ȸ��) <- �� �� �ϳ��� ��Ҷ� �ٲٰ� ������ �� �� ���� ���� ��� ����� ��
        Instantiate(boxPrefab, new Vector3(3,3,0),Quaternion.identity);
        Instantiate(boxPrefab, new Vector3(-1,-2,0), Quaternion.identity);

        //Instantiate �� ��ŭ ������Ʈ ������. <- ������� �� 3���� ������Ʈ ������

        //3. ȸ���� ���� - ���Ϸ� ��(360�� ��)�� ���ʹϿ����� �ٲٱ�
        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        //Instantiate(boxPrefab, new Vector3(2,1,0), rotation);

        //4. ��� ������ ���� ���� �޾Ƽ� �����ϱ�
        GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);
        //��������, Ŭ���� ������ �ٸ��� �Լ� ������ ����� 

        //��� ������ ���� ������Ʈ�� �̸� ����
        clone.name = "Box001";
        //��� ������ ���� ������Ʈ�� ���� ����
        clone.GetComponent<SpriteRenderer>().color = Color.black;
        //��� ������ ���� ������Ʈ�� ��ġ ����
        clone.transform.position = new Vector3(2,1,0);
        //ũ�� ����
        clone.transform.localScale = new Vector3(3, 2, 1);

    }
}
