using UnityEngine;

public class ObstacleBase : MonoBehaviour
{

    [SerializeField]
    private bool isInstantDeath = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��ֹ��� �÷��̾�� �浹���� ���� ���� ó��
        if (!collision.CompareTag("Player")) return;

        if (isInstantDeath)
        {
            collision.GetComponent<PlayerController>().OnDie();
        }
        else
        {
            collision.GetComponent<PlayerHP>().DecreaseHP();
        }
    }
}
