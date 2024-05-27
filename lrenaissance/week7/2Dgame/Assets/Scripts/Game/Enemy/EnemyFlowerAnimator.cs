using UnityEngine;

public class EnemyFlowerAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform spawnPoint;
    //[SerializeField]
    //private Vector3 moveDirection=Vector3.down;

    public void OnFireEvent()
    {
        //발사체의 다양한 방향을 사용할 경우 주석 해제
        /*GameObject clone = */Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity); //발사체 생성
        //clone.GetComponent<MovementTransform2D>().MoveTo(moveDirection);//발사체 이동 방향
    }
}
