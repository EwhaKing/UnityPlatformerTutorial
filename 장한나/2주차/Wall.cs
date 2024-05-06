using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���� �ε��� ������Ʈ�� ����
        Destroy(collision.gameObject);

        //�浹�� �Ͼ�� ���� ������ ��� �����Ѵ�
        StartCoroutine("HitAnimation");
    }

    private IEnumerator HitAnimation()
    {
        SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        SpriteRenderer.color = Color.white; 
    }

}
