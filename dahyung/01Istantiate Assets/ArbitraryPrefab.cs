using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbitraryPrefab : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabArray;

    private void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            int index = Random.Range(0, prefabArray.Length);
            // int value = Random.Range(int main, int max)
            // min부터 max-1까지 정수 중에서 임의의 숫자를 value에 저장

            // float value - Random.Range(float min, float max)
            // min부터 max까지 실수 중에서 임의의 숫자를 value에 저장

            float x = Random.Range(-7.5f, 7.5f); // 
            float y = Random.Range(-4.5f, 4.5f);
            Vector3 position = new Vector3(x, y, 0);

            Instantiate(prefabArray[index], position, Quaternion.identity);
        }
    }
}
