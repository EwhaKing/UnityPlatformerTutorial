using UnityEngine;

public class ObjectSpawner2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabArray;//여러개의 prefab 등록 가능 

    private void Awake()
    {
        for(int i=0;i<10;++i)
        {
            //Random.Range: min~max-1까지의 정수 중 임의의 숫자
            int index=Random.Range(0,prefabArray.Length);
            Vector3 pos = new Vector3(-4.5f + i, 0, 0);

            Instantiate(prefabArray[index], pos, Quaternion.identity);
  
        }
    }
}
