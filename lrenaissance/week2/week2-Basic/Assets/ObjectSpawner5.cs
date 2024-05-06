using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner5 : MonoBehaviour
{
    [SerializeField]
    private int objSpawnCnt = 30;
    [SerializeField]
    private GameObject[] prefabArray;
    [SerializeField]
    private Transform[] spawnPointArray;
    private int currentObjCnt = 0; //현재까지 생성한 obj 개수
    private float objSpawnTime = 0.0f;

    private void Update()//매 프레임마다 호출됨
    {
        //objSpawnCnt 개수만큼만 생성 후 더이상 생성하지 않도록 하기 위해 설정
        if(currentObjCnt+1>objSpawnCnt)
        {
            return;
        }
        //원하는 시간마다 오브젝트를 생성하기 위한 시간 변수 연산
        objSpawnTime += Time.deltaTime;

        //0.5초에 한번씩 실행
        if (objSpawnTime >= 0.5f)
        {
            //obj 생성
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex= Random.Range(0, spawnPointArray.Length);

            Vector3 pos = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex],pos,Quaternion.identity);

            //spawnIndex==0인 obj-> 왼쪽에 있으니 오른쪽으로 이동
            //spawnIndex==1인 obj-> 오른쪽에 있으니 왼쪽으로 이동
            Vector3 moveDir = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D>().Setup(moveDir);

            currentObjCnt++;//생성 obj 개수 1 증가
            objSpawnTime = 0.0f;//시간 0 초기화->0.5초 다시 계산
        }
    }
}
