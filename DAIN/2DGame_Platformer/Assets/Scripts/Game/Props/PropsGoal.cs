using UnityEngine;

public class PropsGoal : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if ( collision.CompareTag("Player") )
		{
			//Debug.Log("Game Clear");
			collision.GetComponent<PlayerController>().LevelComplete();
		}
	}
}
