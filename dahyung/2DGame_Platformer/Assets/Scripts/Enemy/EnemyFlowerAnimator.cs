using UnityEngine;

public class EnemyFlowerAnimator : MonoBehaviour
{
	[SerializeField]
	private	GameObject	projectilePrefab;
	[SerializeField]
	private	Transform	spawnPoint;

	public void OnFireEvent()
	{
		Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
	}
}

