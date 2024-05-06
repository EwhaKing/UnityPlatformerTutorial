using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        /*//반복문으로 10개 회전하는 박스
        for(int i = 0; i < 10; ++i)
        {
            Vector3 pos = new Vector3(-4.5f + i, 0, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, i * 10);

            Instantiate(boxPrefab, pos, rotation);
        }*/

        for(int y=0; y < 10; ++y)
        {
            for(int x=0; x < 10; ++x)
            {
                if (x+y==4||x-y==5||y-x==5||x+y==14) //x자 모양
                {
                    //특정 위치에 생성 안하기
                    continue;
                }
                Vector3 pos = new Vector3(-4.5f + x, 4.5f-y, 0);

                Instantiate(boxPrefab, pos, Quaternion.identity);
            }
        }
    }
}
