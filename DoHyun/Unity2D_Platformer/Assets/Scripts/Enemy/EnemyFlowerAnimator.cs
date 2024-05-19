using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlowerAnimator : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; //적의 발사체 오브젝트
    [SerializeField] private Transform spawnPoint; //발사체가 생성되는 위치
    //[SerializeField] private Vector3 moveDirection = Vector3.down;
    // Start is called before the first frame update
    public void OnFireEnvent()
    {
        //현재는 위에서 아래로만 쏨
        //발사체의 방향을 다양하게 배치한다면 주석을 해제하고, 맵에 배치된 적의 발사체 이동 방향을 EnemyFlowerAnimator 컴포넌트의 moveDirection 변수를 지정해 설정한다.
        //GameObject clone =
        Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        //clone.GetComponent<MovementTrasform2D>().MoveTo(moveDirection);
    }
}
