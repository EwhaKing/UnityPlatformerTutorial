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
		effector.rotationalOffset = 180; // 180���� ������ �Ʒ��� �հ� ��, 0���� �Ʒ����� ���� �հ� ��

		yield return new WaitForSeconds(0.5f);

		effector.rotationalOffset = 0;
	}
}

