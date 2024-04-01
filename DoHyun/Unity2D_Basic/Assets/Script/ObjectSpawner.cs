using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject boxPrefab;
    private void Awake()
    {
        Instantiate(boxPrefab);
        Instantiate(boxPrefab, new Vector3(3, 3, 0), Quaternion.identity);


        //오일러 값을 쿼터니온 값으로 변환
        Quaternion rotation = Quaternion.Euler(0, 0, 45);

        //복제된 오브젝트 정보를 변수에 저장할 수 있다.
        GameObject clone = Instantiate(boxPrefab, new Vector3(-1, -1, 0), rotation);

        clone.name = "Box001";
        clone.GetComponent<SpriteRenderer>().color = Color.black;
        clone.transform.position = new Vector3(-5, -3, 0);
        clone.transform.localScale = new Vector3(3, 2, 1);

    }
}
