using UnityEngine;

public class ObjectSpawnerRowCol : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        // �ܺ� �ݺ��� (������ y�� �������� Ȱ���)
        for (int y = 0; y < 10; ++y)
        {
            // ���� �ݺ��� (������ x�� �������� Ȱ���)
            for (int x = 0; x < 10; ++x)
            {
                // Ư�� ��ġ�� ������Ʈ ���� X
                /* if (x == y || x+y == 9)
                 {
                     continue;
                 }*/

                // ������� ���� X
                if (x + y == 4 || x - y == 5 || y - x == 5 || x + y == 14)
                {
                    continue;
                }

                Vector3 position = new Vector3(-4.5f + x, 4.5f - y, 0);

                Instantiate(boxPrefab, position, Quaternion.identity);
            }
        }
    }
}
