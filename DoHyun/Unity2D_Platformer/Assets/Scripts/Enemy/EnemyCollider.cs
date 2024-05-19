using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private EnemyBase enemyBase; //적 사망 여부 확인과 적 사망할 때 OnDie()메소드 호출을 위함
    private void Awake()
    {
        enemyBase = GetComponentInParent<EnemyBase>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //이미 적이 사망하는 OnDie() 메소드 호출한 상태
        if (enemyBase.IsDie == true) return;

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHP>().DecreseHP();
        }

        else if (other.CompareTag("PlayerProjectile")) //충돌한 오브젝트가 플레이어 발사체인 경우
        {
            enemyBase.OnDie(); //적 사망처리
            Destroy(other.gameObject); //플레이어 발사체 오브젝트 삭제
        }
    }
}
