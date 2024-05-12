using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawnForce = new Vector2(1, 7); //아이템이 생성될 때 이동 힘
    [SerializeField]
    private float aliveTimeAfterSpawn = 5; //생성된 아이템이 삭제될 때까지 걸리는 시간

    private bool allowCollect = true; //아이템 획득 가능 여부

    public void Setup()
    {
        StartCoroutine(nameof(SpawnItemProcess));
    }

    //아이템 타일, 상자에서 생성된 아이템 처리를 위한 메소드
    //아이템이 튀어올랐다가 아래로 '떨어질 때' 획득이 가능하도록 한다. 
    private IEnumerator SpawnItemProcess()
    {
        //아이템이 위로 올라가는 동안은 획득 불가능 상태로 설정
        allowCollect = false;


        //아이템이 중력을 받아 위로 튀어 올랐다 추락하고, 바닥과 충돌할 수 있도록 Rigidbody2D 컴포넌트 추가
        var rigid = gameObject.AddComponent<Rigidbody2D>();
        rigid.freezeRotation = true; //회전해서 데굴데굴 굴러가지 않도록 roatate를 freeze 한다
        rigid.velocity = new Vector2(Random.Range(-spawnForce.x, spawnForce.x), spawnForce.y); //아이템의 속력 : x는 좌/우 임의의 방향으로 설정, y는 7로 설정하여 위로 튀어오르도록 한다.

        while (rigid.velocity.y > 0) //아이템이 위로 올라가는 동안
        {
            yield return null;
        }

        //아이템이 떨어지기 시작하면 획득 가능 상태로 변경
        allowCollect = true;
        //아이템이 바닥과 충돌해서 서있을 수 있도록 trigger를 off
        GetComponent<Collider2D>().isTrigger = false;

        //aliveTime이 지나면 아이템이 삭제되도록한다.
        yield return new WaitForSeconds(aliveTimeAfterSpawn);
        Destroy(gameObject);
    }

    //미리 배치해둔 아이템의 경우 Collider2D 컴포넌트의 isTrigger가 true인 상태이므로 OnTrigger 메소드를 호출
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (allowCollect && other.CompareTag("Player"))
        {
            UpdateCollision(other.transform);
            Destroy(gameObject);
        }
    }
    //아이템 타일, 아이템 상자에서 생성한 아이템의 경우 Collider2D 컴포넌트의 isTrigger가 false인 상태이므로 OnCollider 메소드를 호출
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (allowCollect && other.transform.CompareTag("Player"))
        {
            UpdateCollision(other.transform);
            Destroy(gameObject);
        }

    }

    public abstract void UpdateCollision(Transform target);

}
