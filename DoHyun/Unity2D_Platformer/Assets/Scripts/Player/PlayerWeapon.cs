using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform spawnPoint;

    public void StartFire(int direction)
    {
        //projectile 오브젝트 생성
        GameObject clone = Instantiate(projectile, spawnPoint.position, Quaternion.identity);
        //발사체의 이동방향을 설정하여 발사
        clone.GetComponent<PlayerProjectile>().Setup(direction);
    }
}
