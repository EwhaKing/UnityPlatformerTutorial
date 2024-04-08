using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//오브젝트가 특정 위치를 벗어났을 때 삭제되도록 하는 스크립트
public class PositionAutoDestroyer : MonoBehaviour
{
    //오브젝트의 x 또는 y 위치가 정해진 범위를 벗어나면 삭제되도록 한다.

    //먼저 정해진 범위를 설정한다. (최소, 최대)
    Vector2 limitMin = new Vector2(-7.5f, -4.5f);
    Vector2 limitMax = new Vector2(7.5f, 4.5f);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //이 스크립트를 가지고 있는 게임 오브젝트의 x, y 좌표가 범위 밖으로 벗어나면 오브젝트를 삭제한다.
        if (transform.position.x > limitMax.x || transform.position.x < limitMin.x || transform.position.y > limitMax.y || transform.position.y < limitMin.y)
        {
            Destroy(gameObject);
        }
    }
}
