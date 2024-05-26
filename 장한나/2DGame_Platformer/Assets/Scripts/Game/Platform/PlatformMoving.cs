using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField]
    private Transform target; //실제 이동하는 발판의 Transform

    //발판에 충돌한 플레이어 오브젝트의 부모를 발판으로 설정(발판이 움직일 때 발판과 함께 움직이도록 하기 위해)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(target.transform);
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
