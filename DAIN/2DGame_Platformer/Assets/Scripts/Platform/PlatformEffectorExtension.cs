using System.Collections;
using UnityEngine;

public class PlatformEffectorExtension : MonoBehaviour
{
	private	PlatformEffector2D	effector;

	private void Awake()
	{
		effector = GetComponent<PlatformEffector2D>();
	}

	public void OnDownWay()
	{
		StartCoroutine(nameof(ReverserotationalOffset));
	}

	private IEnumerator ReverserotationalOffset()
	{
		effector.rotationalOffset = 180; // 180도면 위에서 아래로 뚫고 감, 0도면 아래에서 위로 뚫고 감

		yield return new WaitForSeconds(0.5f);

		effector.rotationalOffset = 0;
	}
}

