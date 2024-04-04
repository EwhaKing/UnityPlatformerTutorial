using UnityEngine;

public class objSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        //Instantiate(boxPrefab); //인자로 받는 게임 obj(prefab)를 복제해서 생성

        //인자로 (GameObject original, Vector3 pos, Quaternion rotation)
        //original obj를 복제 생성->복제본의 위치를 pos로, 회전을 rotation으로
        //Instantiate(boxPrefab,new Vector3(3,3,0),Quaternion.identity);

        //Instantiate(boxPrefab, new Vector3(-1, -2, 0), Quaternion.identity);

        //회전값
        Quaternion rotation = Quaternion.Euler(0, 0, 45);

        //Instantiate(boxPrefab, new Vector3(2, 1, 0), rotation);

        //생성 obj를 clone에 저장
        GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);

        //obj 이름
        clone.name = "Box001";
        //obj 색
        clone.GetComponent<SpriteRenderer>().color = Color.black;
        //obj 위치
        clone.transform.position = new Vector3(2, 1, 0);
        //obj 크기
        clone.transform.localScale = new Vector3(3, 2, 1);
    
    }
}
