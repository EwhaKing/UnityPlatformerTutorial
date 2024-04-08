using UnityEngine;

public class ObjectSpawner4 : MonoBehaviour
{
    [SerializeField]
    private int objSpawnCnt = 30;
    [SerializeField]
    private GameObject[] prefabArray;
    [SerializeField]
    private Transform[] spawnPointArray;

    private void Awake()
    {
        for (int i = 0; i < objSpawnCnt; ++i)
        {
            //임의의 위치로 spawn되도록 함
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 pos = spawnPointArray[spawnIndex].position;
             GameObject clone=Instantiate(prefabArray[prefabIndex], pos, Quaternion.identity);

            //spawnIndex==0인 obj-> 왼쪽에 있으니 오른쪽으로 이동
            //spawnIndex==1인 obj-> 오른쪽에 있으니 왼쪽으로 이동
            Vector3 moveDir = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D>().Setup(moveDir);
        }
    }
}
