using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_Practice : MonoBehaviour
{
    [SerializeField]
    //private GameObject boxPrefab;
    //게임 오브젝트를 배열 형태로 받기
    private GameObject[] prefabArray;

    [SerializeField]
    int ObjectSpawnerCount = 30;
    int currentObjectCount = 0; //현재까지 생성한 오브젝트 개수
    float objectSpawnTime = 0.0f;


    [SerializeField]
    private Transform[] spawnPointArray; //spawnPoint를 저장하기 위한 배열

    // Start is called before the first frame update

    private void Awake()
    {
        //1. 반복문을 통해 10개의 오브젝트 생성
        // for (int i = 0; i < 10; i++)
        // {
        //     //반복 횟수 i를 통해 10개 오브젝트의 위치와 회전을 서서히 증가하도록 설정
        //     Vector3 position = new Vector3(-4.5f + i, 0, 0);
        //     Quaternion rotation = Quaternion.Euler(0, 0, i * 10); //10도씩 돌아가도록 함

        //     Instantiate(boxPrefab, position, rotation);
        // }


        //2. 이중 반복문을 사용해 격자 형태의 사각맵 표현 가능(직접 작성해보기)
        //외부 반복문 (격자의 y축 계산용)
        // for (int i = 0; i < 10; i++)
        // {
        //     //내부 반복문(격자의 x축 계산용)
        //     for (int j = 0; j < 10; j++)
        //     {

        //         //반복문 내부에 조건문을 사용해 특정 위치에 오브젝트를 생성하지 않도록 처리
        //         //if (i == j || i + j == 9) //x 형태로 생성되지 않음
        //         if (i + j == 4 || j - i == 5 || i + j == 14 || i - j == 5)
        //         {
        //             continue;
        //         }
        //         Vector3 postiion = new Vector3(-4.5f + j, -4.5f + i, 0);
        //         Instantiate(boxPrefab, postiion, Quaternion.identity);
        //     }
        // }



        //3. 여러 프리팹 중 하나를 랜덤하게 선택하기
        // for (int i = 0; i < 10; i++)
        // {
        //     int index = Random.Range(0, prefabArray.Length); //유니티에서 제공하는 함수
        //     //int value = Random.Range(int min, int max); : min부터 max-1까지 정수 중에서 임의의 숫자를 value에 저장
        //     //float value = Random.Range(float min, float max) : min부터 max까지의 실수 중에서 임의의 숫자를 value에 저장
        //     //따라서 위의 index 변수에서는 0~prefabArray의 길이-1(=0부터 마지막 인덱스까지)까지의 중수 중에서 임의의 숫자가 저장된다. 배열 내 모두 요소 중 무작위로 하나를 가져올 수 있다.

        //     Vector3 position = new Vector3(-4.5f + i, 0, 0);
        //     Instantiate(prefabArray[index], position, Quaternion.identity);
        // }


        //4. Random.Range 함수를 사용하여 복제한 게임 오브젝트의 위치를 임의로 정하기
        // for (int i = 0; i < ObjectSpawnerCount; i++)
        // {
        //     int index = Random.Range(0, prefabArray.Length); //배열 중 임의로 하나를 선택하기 위한 랜덤 함수
        //     float x = Random.Range(-7.5f, 7.5f);
        //     float y = Random.Range(-5.5f, 5.5f);
        //     Vector3 position = new Vector3(x, y, 0);

        //     Instantiate(prefabArray[index], position, Quaternion.identity);

        // }

        //5. SpawnPoint에서 오브젝트 생성 -> Awake 함수는 게임이 시작되자마자 1회만 호출되기 때문에 오브젝트가 한꺼번에 생성되어 같이 움직인다. -> 따라서 update() 함수로 생성 코드를 옮긴다.
        // for (int i = 0; i < ObjectSpawnerCount; i++)
        // {
        //     int prefabIndex = Random.Range(0, prefabArray.Length);
        //     int spawnIndex = Random.Range(0, spawnPointArray.Length);

        //     Vector3 position = spawnPointArray[spawnIndex].position;
        //     GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

        //     //삼항 연산자를 이용해서 spawnIndex가 0인 오브젝트는 왼쪽에 있기 때문에 오른쪽으로 이동시키고
        //     //spawnIndex가 1인 오브젝트는 오른쪽에 있기 때문에 왼쪽으로 이동시킨다.
        //     Vector3 moveDirection = (spawnIndex == 0) ? Vector2.right : Vector3.left;
        //     //오브젝트의 Movement2D_2 컴포넌트에 접근하여 이동 방향을 설정해준다.
        //     clone.GetComponent<Movement2D_2>().Setup(moveDirection);
        // }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //업데이트는 매 프레임마다 호출되므로 우리가 원할때만 게임 오브젝트가 생성될 수 있도록 조건문을 만들어야 한다.
        //또한 생성 개수가 정해져 있는 경우 제한도 걸어주어야 한다.
        if (currentObjectCount >= ObjectSpawnerCount)
        {
            return;
        }
        objectSpawnTime += Time.deltaTime; //deltaTime만 덧셈으로 더하게 되면 실제 초와 동일한 시간이 흐르게 된다.
        if (objectSpawnTime >= 0.5f)
        {

            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

            //삼항 연산자를 이용해서 spawnIndex가 0인 오브젝트는 왼쪽에 있기 때문에 오른쪽으로 이동시키고
            //spawnIndex가 1인 오브젝트는 오른쪽에 있기 때문에 왼쪽으로 이동시킨다.
            Vector3 moveDirection = (spawnIndex == 0) ? Vector2.right : Vector3.left;
            //오브젝트의 Movement2D_2 컴포넌트에 접근하여 이동 방향을 설정해준다.
            clone.GetComponent<Movement2D_2>().Setup(moveDirection);

            //오브젝트를 생성했으면 현재까지 생성한 오브젝트 수를 증가시켜준다.
            currentObjectCount++;
            //objectSpawnTime도 리셋하여 다시 0.5초 후에 오브젝트가 생성될 수 있도록 한다.
            objectSpawnTime = 0.0f;

        }
    }
}
