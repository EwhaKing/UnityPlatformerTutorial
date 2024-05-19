using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsSign : MonoBehaviour
{
    [SerializeField]
    private GameObject guideObject; //표지판과 충돌했을 때 활성/비활성화할 오브젝트

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            guideObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            guideObject.SetActive(false);
        }
    }
}
