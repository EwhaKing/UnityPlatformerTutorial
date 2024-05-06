using UnityEngine;

public class ObjectSpawnerRowCol : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        // 외부 반복문 (격자의 y축 계산용으로 활용됨)
        for (int y = 0; y < 10; ++y)
        {
            // 내부 반복문 (격자의 x축 계산용으로 활용됨)
            for (int x = 0; x < 10; ++x)
            {
                // 특정 위치의 오브젝트 생성 X
                /* if (x == y || x+y == 9)
                 {
                     continue;
                 }*/

                // 마름모꼴 생성 X
                if (x + y == 4 || x - y == 5 || y - x == 5 || x + y == 14)
                {
                    continue;
                }

                Vector3 position = new Vector3(-4.5f + x, 4.5f - y, 0);

                Instantiate(boxPrefab, position, Quaternion.identity);
            }
        }
    }
}
