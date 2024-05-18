using UnityEngine;

public class EnemyMushroom : EnemyBase
{
	private	FollowPath		followPath;
	private	SpriteRenderer	spriteRenderer;
	private	Animator		animator;

	private void Awake()
	{
		followPath		= GetComponent<FollowPath>();
		spriteRenderer	= GetComponentInChildren<SpriteRenderer>();
		animator		= GetComponentInChildren<Animator>();
	}

	private void Update() // 오른쪽을 보고 있는 이미지라면 true, false 위치 반대로 설정
	{
		spriteRenderer.flipX = followPath.Direction == 1 ? true : false;
		animator.SetFloat("moveSpeed", (int)followPath.State);
	}

	public override void OnDie()
	{
		if ( IsDie == true ) return;

		IsDie = true;

		followPath.Stop();
		animator.SetTrigger("onDie");
	}
}

