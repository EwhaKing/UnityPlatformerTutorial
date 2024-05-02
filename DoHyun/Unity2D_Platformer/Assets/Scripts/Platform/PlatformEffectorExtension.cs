using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffectorExtension : MonoBehaviour
{
    private PlatformEffector2D effector;

    private void Awake()
    {
        effector = GetComponent<PlatformEffector2D>();
    }



    public void OnDownWay()
    {
        StartCoroutine(nameof(ReverseRotationalOffset));
    }

    //현재 PlatformEffector2D 컴포넌트의 설정은
    //아래에서 위는 뚫고 지나가고, 위에서 아래로는 충돌가능하기 때문에 플레이어가 위에 서 있을 수 있다.
    IEnumerator ReverseRotationalOffset()
    {
        //rotationalOffset의 회전 각도를 180으로 뒤집어주면 위에서 아래로 뚫고 갈 수도 있고, 아래에서 위로 충돌 가능한 상태로 바뀌기 때문에
        //위에 있던 플레이어가 아래로 떨어지게 된다.
        effector.rotationalOffset = 180;

        //0.5초 후에 다시 기존 상태로 복원
        yield return new WaitForSeconds(0.5f);

        effector.rotationalOffset = 0;

    }
}
