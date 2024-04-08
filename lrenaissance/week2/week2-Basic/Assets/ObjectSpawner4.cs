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
            //������ ��ġ�� spawn�ǵ��� ��
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 pos = spawnPointArray[spawnIndex].position;
             GameObject clone=Instantiate(prefabArray[prefabIndex], pos, Quaternion.identity);

            //spawnIndex==0�� obj-> ���ʿ� ������ ���������� �̵�
            //spawnIndex==1�� obj-> �����ʿ� ������ �������� �̵�
            Vector3 moveDir = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D>().Setup(moveDir);
        }
    }
}
