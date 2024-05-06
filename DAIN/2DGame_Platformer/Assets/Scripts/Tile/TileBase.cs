using System.Collections;
using UnityEngine;

public class TileBase : MonoBehaviour
{
	[SerializeField]
	private	bool	canBounce = false;	// Bounce 가능 여부
	private	float	startPositionY;		// 타일의 최초 y 위치

	// 타일과 플레이어가 충돌했는지 체크 (일정시간동안 다시 충돌체크를 하지 않도록)
	public	bool	IsHit { private set; get; } = false;

	private void Awake()
	{
		startPositionY = transform.position.y;
	}

	public virtual void UpdateCollision()
	{
		//Debug.Log($"{gameObject.name} 타일 충돌");

		if ( canBounce == true )
		{
			IsHit = true;

			StartCoroutine(nameof(OnBounce));
		}
	}

	private IEnumerator OnBounce()
	{
		float maxBounceAmount = 0.35f;	// 타일이 충돌해 올라가는 최대 높이

		// 코루틴 메소드 내부에서 yield return으로 다른 코루틴 메소드를 실행하면 해당 코루틴 메소드 실행이 종료된 이후 아래에 있는 코드로 넘어감
		yield return StartCoroutine(MoveToY(startPositionY, startPositionY + maxBounceAmount));

		yield return StartCoroutine(MoveToY(startPositionY + maxBounceAmount, startPositionY));

		IsHit = false; // 다시 충돌 가능하게 false로
	}

	private IEnumerator MoveToY(float start, float end)
	{
		float percent	 = 0;
		float bounceTime = 0.2f;

		while ( percent < 1 )
		{
			percent += Time.deltaTime / bounceTime;

			Vector3 position = transform.position;
			position.y = Mathf.Lerp(start, end, percent);
			transform.position = position;

			yield return null;
		}
	}
}

