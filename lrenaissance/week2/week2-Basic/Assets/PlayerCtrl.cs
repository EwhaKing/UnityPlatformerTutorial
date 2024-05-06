using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour //�� �߻�
{
    [SerializeField]
    private KeyCode keyCodeFire=KeyCode.Space;//�����̽���
    [SerializeField]
    private GameObject bulletPrefab;
    private float moveSpeed = 3.0f;
    private Vector3 lastMoveDir = Vector3.right;//�������� �������� ���� ����

    private void Update()
    {
        //player obj �̵�
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;

        if(x!=0 || y != 0)//�������� �Էµ� ����Ű�� ������ �Ѿ��� �߻� �������� Ȱ��
        {
            lastMoveDir=new Vector3(x,y,0);
        }

        //player obj �Ѿ� �߻�
        if(Input.GetKeyDown(keyCodeFire)) //�����̽��� ������ ����
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;

            clone.GetComponent<Movement2D>().Setup(lastMoveDir);//���Ⱚ ����
        }
    }
}
