using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    //SpawnPoint에서 오브젝트 생성

    [SerializeField]
    private int objectSpawnCount = 30;

    [SerializeField]
    private GameObject[] prefabArray;

    [SerializeField]
    private Transform[] spawnPointArray;

    private int currentObjectCount = 0; // 현재까지 생성한 오브젝트 개수
    private float objectSpawnTime = 0.0f;

    /*private void Awake()
    {
       /* 기본
        * for(int i = 0; i < objectSpawnCount; ++i)
        {
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);
        }*/

    /* SpawnPoint에서 오브젝트 생성 + 이동 시키기
    /*for (int i = 0; i<objectSpawnCount; ++i)
    {
        int prefabIndex = Random.Range(0, prefabArray.Length);
        int spawnIndex = Random.Range(0, spawnPointArray.Length);

        Vector3 position = spawnPointArray[spawnIndex].position;
        GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

        //spawnIndex가 0인 오브젝트가 왼쪽에 있기 때문에 오른쪽으로 이동
        //spawnIndex가 1인 오브젝트가 오른쪽에 있기 때문에 왼쪽으로 이동
        Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
        clone.GetComponent<Movement2D>().Setup(moveDirection);
    }

    } */

    /*
    private void Update()
    {
        //0.5초마다 한 번씩 생성
        if (currentObjectCount + 1 > objectSpawnCount) //objectSpawncount 개수만큼만 생성하고 더이상 생성하지 않도록 하기 위해 설정
        {
            return;
        }

        //원하는 시간마다 오브젝트를 생성하기 위한 시간 변수 연산
        objectSpawnTime += Time.deltaTime;

        //0.5초에 한 번씩 실행
        if (objectSpawnTime >= 0.5f)
        {
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

            //spawnIndex가 0인 오브젝트가 왼쪽에 있기 때문에 오른쪽으로 이동
            //spawnIndex가 1인 오브젝트가 오른쪽에 있기 때문에 왼쪽으로 이동
            Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D>().Setup(moveDirection);

            currentObjectCount++; //현재 생성된 오브젝트의 개수를 1 증가시킨다
            objectSpawnTime = 0.0f; // 시간을 0으로 초기화해야 다시 0.5초를 계산할 수 있다. 
        }
    }*/

}

