
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroomAnimator : MonoBehaviour
{
    [SerializeField] private GameObject parent; //삭제할 부모 오브젝트


    //애니메이션을 재생할 때 특정 프레임에서 호출하는 이벤트 메소드의 경우 Animator 컴포넌트와 같은 게임오브젝트에 소속되어야 한다.
    public void OnDieEvent()
    {
        Destroy(parent);
    }
}
