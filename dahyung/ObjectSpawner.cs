using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        // 1. Instantiate(원본 오브젝트)
        // Instantiate(boxPrefab); 
        // original gameobjcet를 복제해서 생성(복제되는 오브젝트의 모든 컴포넌트 정보가 원본과 완전히 동일)

        
        // 2. Instantiate(원본오브젝트, 위치, 회전)
        // Instantiate(boxPrefab, new Vector3(3, 3, 0), Quaternion.identity); 
        // Instantiate(boxPrefab, new Vector3(-1, -2, 0), Quaternion.identity); 
        // original 게임 오브젝트를 복제헤서 생성하고 생성된 복제본의 위치를 position으로, 회전은 rotation으로 설정
        

        // 3. 회전 값 설정
        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        Instantiate(boxPrefab, new Vector3(2, 1, 0), rotation);


        // 4. 방금 생성된 복제 정보 받아서 설정하기
        GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);

        // 방금 생성된 게임 오브젝트의 이름 변경
        clone.name = "Box001";
        // 방금 생성된 게임 오브젝트의 색상 변경
        clone.GetComponent<SpriteRenderer>().color = Color.black;
        // 방금 생성된 게임 오브젝트의 위치 변경
        clone.transform.position = new Vector3(2, 1, 0);
        // 크기 변경
        clone.transform.localScale = new Vector3(3, 2, 1);

    }
}
