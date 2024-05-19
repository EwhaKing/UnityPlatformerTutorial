using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public bool IsDie { protected set; get; } = false; //현재 사망 상태 여부, 자식 클래스에서만 set할 수 있도록 protected로 정의

    public abstract void OnDie();

}
