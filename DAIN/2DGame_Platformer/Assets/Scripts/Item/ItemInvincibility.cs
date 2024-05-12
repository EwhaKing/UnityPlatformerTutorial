using UnityEngine;

public class ItemInvincibility : ItemBase
{
	[SerializeField]
	private	float time = 3; // 3ÃÊ ¹«Àû

	public override void UpdateCollision(Transform target)
	{
		target.GetComponent<PlayerHP>().OnInvincibility(time);
	}
}

