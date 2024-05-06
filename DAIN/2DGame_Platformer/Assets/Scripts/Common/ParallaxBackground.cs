using UnityEngine;

[System.Serializable]
public struct BackgroundData
{
	public	Renderer background;
	public	float speed;
}

public class ParallaxBackground : MonoBehaviour
{
	[SerializeField]
	private Transform	targetCamera; // ����� ��ũ���ϱ� ���� ������ �Ǵ� ī�޶��� Transform�� ����
	[SerializeField]
	private BackgroundData[] backgrounds; // targetCamera�� �̵��� ���� ��ũ�ѵǴ� ���ȭ����� ����
	[SerializeField]
	private BackgroundData backgroundCloud; // targetCamera�� �̵��� ������� ���������� �����̴� ���� ����� ����
	
	private float targetStartX; // ī�޶� ���� x ��ġ

	private void Awake()
	{
		targetStartX = targetCamera.position.x;
	}

	private void Update()
	{
		float cloudOffset = Time.time * backgroundCloud.speed; // ��� ������
		// why? Time.time�� ����ð����� ��� ������
		backgroundCloud.background.material.mainTextureOffset = new Vector2(cloudOffset, 0);

        if ( targetCamera == null ) return;

		float x = targetCamera.position.x - targetStartX; // ���� x��ġ - ���� x��ġ
		for ( int i = 0; i < backgrounds.Length; ++ i )
		{
			float offset = x * backgrounds[i].speed;
			backgrounds[i].background.material.mainTextureOffset = new Vector2(offset, 0);
		}
	}
}


