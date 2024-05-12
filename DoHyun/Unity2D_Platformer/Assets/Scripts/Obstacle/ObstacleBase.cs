using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어와 충돌했을 때 플레이어의 체력이 감소하거나 플레이어가 사망하도록 설정
public class ObstacleBase : MonoBehaviour
{
    [SerializeField]
    //즉사 여부를 설정하는 변수. true면 즉사 장애물, false면 체력 감소 장애물
    private bool isInstantDeath = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //장애물은 플레이어와 충돌했을 때만 로직을 처리
        if (!other.CompareTag("Player")) return;

        if (isInstantDeath)
        {
            Debug.Log("플레이어 사망"); //체력 시스템 만들고 수정
        }
        else
        {
            //Debug.Log("플레이어 체력 감소");//체력 시스템 만들고 수정
            other.GetComponent<PlayerHP>().DecreseHP();
        }
    }
}
