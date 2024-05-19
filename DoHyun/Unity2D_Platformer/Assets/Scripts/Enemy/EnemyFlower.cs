using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlower : MonoBehaviour
{
    [SerializeField] private float attackRate = 2; //공격 주기
    private float currentTime = 0; //공격 주기 시간 계산을 위한 변수
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private IEnumerator Start()
    {
        while (true)
        {
            //attackRate 값인 2초에 한번씩 공격 애니메이션을 재생하고, 발사체 생성
            if (Time.time - currentTime > attackRate) //현재 시간 - currentTime 이 attackRate보다 크면 발사
            {
                animator.SetTrigger("onFire");
                currentTime = Time.time;
            }
            yield return null;
        }
    }
}
