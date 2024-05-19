using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//적의 발사체 제어
public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHP>().DecreseHP();
        }
    }
}
