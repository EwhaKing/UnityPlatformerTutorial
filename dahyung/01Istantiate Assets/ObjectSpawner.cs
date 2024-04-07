using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
     private GameObject boxPrefab;

    private void Awake()
    {
        // for (int i = 0; i < 10; ++i)
        // {
        //     Vector3 position = new Vector3(-4.5f + i, 0, 0);
        //     Quaternion rotation = Quaternion.Euler(0, 0, i * 10);

        //     Instantiate(boxPrefab, position, rotation);
        // }



        // 외부 반복문 (격자의 y축 계산용으로 활용됨)
        for(int y = 0; y < 10; y+=2)
        {
            // 내부 반복문 (격자의 x축 계산용으로 활용됨)
            for(int x = 0; x <10; x+=2)
            {
                if ( x == y || x+y == 9 )
                {
                    continue;
                }

                Vector3 position = new Vector3(-4.5f + x, 4.5f - y, 0);

                Instantiate(boxPrefab, position, Quaternion.identity);
            }
        }

    }
}
