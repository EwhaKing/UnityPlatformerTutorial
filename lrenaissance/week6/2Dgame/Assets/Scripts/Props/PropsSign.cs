using UnityEngine;

public class PropsSign : MonoBehaviour
{
    [SerializeField]
    private GameObject guideObject; //충돌 시 활성.비활성

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//표지판과 충돌한 것의 태그가 Player
        {
            guideObject.SetActive(true);//활성화
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            guideObject.SetActive(false);
        }
    }
}
