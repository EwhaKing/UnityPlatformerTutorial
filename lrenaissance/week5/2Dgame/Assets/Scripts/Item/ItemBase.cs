using System.Collections;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawnForce = new Vector2(1, 7);
    [SerializeField]
    private float aliveTimeAfterSpawn = 5;

    private bool allowCollect = true;

    public void Setup()
    {
        //타일.상자에서 생성되는 아이템: 생성시 Setup 호출해서 SpawnItemProcess 코루틴 메소드가 호출되도록
        StartCoroutine(nameof(SpawnItemProcess));
    }

    private IEnumerator SpawnItemProcess()
    {
        allowCollect = false;

        var rigid=gameObject.AddComponent<Rigidbody2D>();
        rigid.freezeRotation = true; //구르지 않게
        rigid.velocity=new Vector2(Random.Range(-spawnForce.x,spawnForce.x),spawnForce.y);

        while (rigid.velocity.y > 0)
        {
            yield return null;
        }

        allowCollect = true;
        GetComponent<Collider2D>().isTrigger = false;

        yield return new WaitForSeconds(aliveTimeAfterSpawn);
        //생성 아이템 aliveTimeAfterSpawn 시간 후 삭제
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(allowCollect&& collision.CompareTag("Player"))//아이템 획득
        {
            UpdateCollision(collision.transform);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (allowCollect && collision.transform.CompareTag("Player"))
        {
            UpdateCollision(collision.transform);
            Destroy(gameObject);
        }
    }

    public abstract void UpdateCollision(Transform target);
}
