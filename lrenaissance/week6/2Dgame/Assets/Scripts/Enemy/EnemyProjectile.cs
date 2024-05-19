using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);//충돌 발생시 무조건 삭제

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().DecreaseHP();
        }
    }
}
