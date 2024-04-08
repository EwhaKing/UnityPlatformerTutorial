using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner3 : MonoBehaviour
{
    [SerializeField]
    private int objSpawnCnt=30;
    [SerializeField]
    private GameObject[] prefabArray;

    private void Awake()
    {
        //30개의 obj 임의의 위치로
        for(int i = 0; i < objSpawnCnt; ++i)
        {
            int index = Random.Range(0, prefabArray.Length);
            float x = Random.Range(-7.5f, 7.5f);//x위치
            float y = Random.Range(-4.5f, 4.5f);//y위치
            Vector3 pos = new Vector3(x, y, 0);

            Instantiate(prefabArray[index], pos, Quaternion.identity);
        }
    }
}
