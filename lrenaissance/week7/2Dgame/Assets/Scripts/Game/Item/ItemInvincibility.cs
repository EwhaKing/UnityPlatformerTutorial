using UnityEngine;

public class ItemInvincibility : ItemBase
{
    [SerializeField]
    private float time = 3;

    public override void UpdateCollision(Transform target)
    {
        target.GetComponent<PlayerHP>().OnInvincibility(time);//무적 아이템 획득시 time 시간동안 무적
    }
}
