using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        // 1. Instantiate() : original 게임오브젝트(prefab)을 복제해서 생성. 복제된 파일 원본과 동일
        // Instantiate(boxPrefab);

        // 2. Instantiate(원본오브젝트, 위치, 회전);
        // Instantiate(boxPrefab, new Vector3(3, 3, 0), Quaternion.identity);
        // Instantiate(boxPrefab, new Vector3(-1, -2, 0), Quaternion.identity);

        // 3. 회전 값 설정
        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        //Instantiate(boxPrefab, new Vector3(2, 1, 0), rotation);

        // 4. 방금 생성된 복제 정보 받아서 설정하기
        GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);

        // 방금 생성된 게임 오브젝트의 이름 변경
        clone.name = "BOX1";
        // " 색상 변경
        clone.GetComponent<SpriteRenderer>().color = 
        Color.black;
        // " 위치 변경
        clone.transform.position = new Vector3(2, 1, 0);
        // " 크기 변경
        clone.transform.localScale = new Vector3(3, 2, 1);

    }
}