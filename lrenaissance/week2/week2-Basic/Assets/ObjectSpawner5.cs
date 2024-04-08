using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner5 : MonoBehaviour
{
    [SerializeField]
    private int objSpawnCnt = 30;
    [SerializeField]
    private GameObject[] prefabArray;
    [SerializeField]
    private Transform[] spawnPointArray;
    private int currentObjCnt = 0; //������� ������ obj ����
    private float objSpawnTime = 0.0f;

    private void Update()//�� �����Ӹ��� ȣ���
    {
        //objSpawnCnt ������ŭ�� ���� �� ���̻� �������� �ʵ��� �ϱ� ���� ����
        if(currentObjCnt+1>objSpawnCnt)
        {
            return;
        }
        //���ϴ� �ð����� ������Ʈ�� �����ϱ� ���� �ð� ���� ����
        objSpawnTime += Time.deltaTime;

        //0.5�ʿ� �ѹ��� ����
        if (objSpawnTime >= 0.5f)
        {
            //obj ����
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex= Random.Range(0, spawnPointArray.Length);

            Vector3 pos = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex],pos,Quaternion.identity);

            //spawnIndex==0�� obj-> ���ʿ� ������ ���������� �̵�
            //spawnIndex==1�� obj-> �����ʿ� ������ �������� �̵�
            Vector3 moveDir = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D>().Setup(moveDir);

            currentObjCnt++;//���� obj ���� 1 ����
            objSpawnTime = 0.0f;//�ð� 0 �ʱ�ȭ->0.5�� �ٽ� ���
        }
    }
}
