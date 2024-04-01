using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //게임오브젝트 생성 함수 : Instantiate
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        //1. Instantiate(원본오브젝트);
        Instantiate(boxPrefab);

        //2. Instantiate(원본오브젝트, 위치, 회전) <- 이 중 하나의 요소라도 바꾸고 싶으면 이 세 가지 값을 모두 써줘야 함
        Instantiate(boxPrefab, new Vector3(3,3,0),Quaternion.identity);
        Instantiate(boxPrefab, new Vector3(-1,-2,0), Quaternion.identity);

        //Instantiate 쓴 만큼 오브젝트 생성됨. <- 여기까지 총 3개의 오브젝트 생성됨

        //3. 회전값 설정 - 오일러 값(360도 값)을 쿼터니온으로 바꾸기
        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        //Instantiate(boxPrefab, new Vector3(2,1,0), rotation);

        //4. 방금 생성된 복제 정보 받아서 설정하기
        GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);
        //지역변수, 클래스 변수와 다르게 함수 끝나면 사라짐 

        //방금 생성된 게임 오브젝트의 이름 변경
        clone.name = "Box001";
        //방금 생성된 게임 오브젝트의 색상 변경
        clone.GetComponent<SpriteRenderer>().color = Color.black;
        //방금 생성된 게임 오브젝트의 위치 변경
        clone.transform.position = new Vector3(2,1,0);
        //크기 변경
        clone.transform.localScale = new Vector3(3, 2, 1);

    }
}
