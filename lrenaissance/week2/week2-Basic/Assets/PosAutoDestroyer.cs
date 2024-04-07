using UnityEngine;

public class PosAutoDestroyer : MonoBehaviour
{
    private Vector2 limitMin = new Vector2(-7.5f, -4.5f);
    private Vector2 limitMax = new Vector2(7.5f, 4.5f);

    private void Update()
    {
        //이 스크립트를 가진 게임오브젝트의 x,y 좌표가 범위 밖으로 벗어나면 오브젝트 삭제
        if(transform.position.x < limitMin.x|| transform.position.x > limitMax.x||
            transform.position.y < limitMin.y || transform.position.y > limitMax.y)
        {
            //gameObject: 본인이 소속된 게임 오브젝트
            Destroy(gameObject);
        }
    }
}
