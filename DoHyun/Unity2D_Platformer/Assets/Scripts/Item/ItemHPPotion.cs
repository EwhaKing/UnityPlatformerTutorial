using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHPPotion : ItemBase
{
    public override void UpdateCollision(Transform target)
    {
        target.GetComponent<PlayerHP>().IncreaseHP();
    }
}
