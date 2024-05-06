using UnityEngine;

public class ObjectSpawner2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabArray;//�������� prefab ��� ���� 

    private void Awake()
    {
        for(int i=0;i<10;++i)
        {
            //Random.Range: min~max-1������ ���� �� ������ ����
            int index=Random.Range(0,prefabArray.Length);
            Vector3 pos = new Vector3(-4.5f + i, 0, 0);

            Instantiate(prefabArray[index], pos, Quaternion.identity);
  
        }
    }
}
