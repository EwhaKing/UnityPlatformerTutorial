using UnityEngine;

public class ObjectSpawnerRandom : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabArray; // �迭 ���� !_!

    [SerializeField]
    private int objectSpawnCount = 30;

    [SerializeField]
    private Transform[] spawnPointArray;
    private int currentObjectCount = 0; // ������� ������ ������Ʈ ����
    private float objectSpawnTime = 0.0f;

    private void Awake()
    {
        /*        for (int i = 0; i < 10; ++i)
                {
                    // Random.Range(min, max) : int�� min ~ max-1����, float�� min ~ max����
                    int index = Random.Range(0, prefabArray.Length);
                    Vector3 position = new Vector3(-4.5f + i, 0, 0);

                    Instantiate(prefabArray[index], position, Quaternion.identity);
                }*/

        // ȭ�� ���ο��� ������ ��ġ�� ������ ������Ʈ ����
        /*       for (int i=0; i<objectSpawnCount; ++i)
               {
                   int index = Random.Range(0, prefabArray.Length);
                   float x = Random.Range(-7.5f, 7.5f); // x ��ġ
                   float y = Random.Range(-4.5f, 4.5f); // y ��ġ
                   Vector3 position = new Vector3(x, y, 0);

                   Instantiate(prefabArray[index], position, Quaternion.identity);
               }*/

        // Ư�� ��������Ʈ�� ���� ������Ʈ ����
        /*        for (int i = 0; i < objectSpawnCount; ++i)
                {
                    int prefabIndex = Random.Range(0, prefabArray.Length);
                    int spawnIndex = Random.Range(0, spawnPointArray.Length); ;

                    Vector3 position = spawnPointArray[spawnIndex].position;
                    GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

                    // spawnIndex�� 0�� ������Ʈ�� ���ʿ� �ֱ� ������ ���������� �̵�
                    // spawnIndex�� 1�� ������Ʈ�� �����ʿ� �ֱ� ������ �������� �̵�
                    Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
                    clone.GetComponent<Movement2D_2>().Setup(moveDirection);
                }*/

    }

    // �������Ӹ��� ȣ���. Awake() ������� ���� �Ѳ����� ������Ʈ ������.
    private void Update()
    {
        // objectSpawnCount ������ŭ�� �����ϰ� ���̻� �������� �ʵ��� �ϱ� ���� ����
        if (currentObjectCount + 1 > objectSpawnCount)
        {
            return;
        }

        // ���ϴ� �ð����� ������Ʈ�� �����ϱ� ���� �ð� ���� ����
        // Time.deltaTime�� ���ؼ� ���� ���� �ð���ŭ �ð��� �帥��
        objectSpawnTime += Time.deltaTime;

        // 0.5�ʿ� �ѹ��� ����
        if (objectSpawnTime >= 0.5f)
        {
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

            // spawnIndex�� 0�� ������Ʈ�� ���ʿ� �ֱ� ������ ���������� �̵�
            // spawnIndex�� 1�� ������Ʈ�� �����ʿ� �ֱ� ������ �������� �̵�
            Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D_2>().Setup(moveDirection);

            currentObjectCount++; // ���� ������ ������Ʈ�� ������ 1 ������Ŵ
            objectSpawnTime = 0.0f; // �ð��� 0���� �ʱ�ȭ�ؾ� �ٽ� 0.05�ʸ� ����� �� ����

        }
    }
}
