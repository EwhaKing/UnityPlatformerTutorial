using UnityEngine;

public class ObjectSpawnerRandom : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabArray; // 배열 형태 !_!

    [SerializeField]
    private int objectSpawnCount = 30;

    [SerializeField]
    private Transform[] spawnPointArray;
    private int currentObjectCount = 0; // 현재까지 생성한 오브젝트 개수
    private float objectSpawnTime = 0.0f;

    private void Awake()
    {
        /*        for (int i = 0; i < 10; ++i)
                {
                    // Random.Range(min, max) : int면 min ~ max-1까지, float면 min ~ max까지
                    int index = Random.Range(0, prefabArray.Length);
                    Vector3 position = new Vector3(-4.5f + i, 0, 0);

                    Instantiate(prefabArray[index], position, Quaternion.identity);
                }*/

        // 화면 내부에서 임의의 위치에 랜덤한 오브젝트 생성
        /*       for (int i=0; i<objectSpawnCount; ++i)
               {
                   int index = Random.Range(0, prefabArray.Length);
                   float x = Random.Range(-7.5f, 7.5f); // x 위치
                   float y = Random.Range(-4.5f, 4.5f); // y 위치
                   Vector3 position = new Vector3(x, y, 0);

                   Instantiate(prefabArray[index], position, Quaternion.identity);
               }*/

        // 특정 스폰포인트에 랜덤 오브젝트 생성
        /*        for (int i = 0; i < objectSpawnCount; ++i)
                {
                    int prefabIndex = Random.Range(0, prefabArray.Length);
                    int spawnIndex = Random.Range(0, spawnPointArray.Length); ;

                    Vector3 position = spawnPointArray[spawnIndex].position;
                    GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

                    // spawnIndex가 0인 오브젝트가 왼쪽에 있기 때문에 오른쪽으로 이동
                    // spawnIndex가 1인 오브젝트가 오른쪽에 있기 때문에 왼쪽으로 이동
                    Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
                    clone.GetComponent<Movement2D_2>().Setup(moveDirection);
                }*/

    }

    // 매프레임마다 호출됨. Awake() 사용했을 때는 한꺼번에 오브젝트 생성됨.
    private void Update()
    {
        // objectSpawnCount 개수만큼만 생성하고 더이상 생성하지 않도록 하기 위해 설정
        if (currentObjectCount + 1 > objectSpawnCount)
        {
            return;
        }

        // 원하는 시간마다 오브젝트를 생성하기 위한 시간 변수 연산
        // Time.deltaTime을 더해서 쓰면 실제 시간만큼 시간이 흐른다
        objectSpawnTime += Time.deltaTime;

        // 0.5초에 한번씩 실험
        if (objectSpawnTime >= 0.5f)
        {
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

            // spawnIndex가 0인 오브젝트가 왼쪽에 있기 때문에 오른쪽으로 이동
            // spawnIndex가 1인 오브젝트가 오른쪽에 있기 때문에 왼쪽으로 이동
            Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D_2>().Setup(moveDirection);

            currentObjectCount++; // 현재 생성된 오브젝트의 개수를 1 증가시킴
            objectSpawnTime = 0.0f; // 시간을 0으로 초기화해야 다시 0.05초를 계산할 수 있음

        }
    }
}
