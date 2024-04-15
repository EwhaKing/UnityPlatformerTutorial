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
	private Transform	targetCamera; // 배경을 스크롤하기 위해 기준이 되는 카메라의 Transform을 저장
	[SerializeField]
	private BackgroundData[] backgrounds; // targetCamera의 이동에 따라 스크롤되는 배경화면들을 저장
	[SerializeField]
	private BackgroundData backgroundCloud; // targetCamera의 이동과 관계없이 지속적으로 움직이는 구름 배경을 저장
	
	private float targetStartX; // 카메라 시작 x 위치

	private void Awake()
	{
		targetStartX = targetCamera.position.x;
	}

	private void Update()
	{
		float cloudOffset = Time.time * backgroundCloud.speed; // 계속 증가함
		// why? Time.time은 현재시간으로 계속 증가함
		backgroundCloud.background.material.mainTextureOffset = new Vector2(cloudOffset, 0);

        if ( targetCamera == null ) return;

		float x = targetCamera.position.x - targetStartX; // 현재 x위치 - 시작 x위치
		for ( int i = 0; i < backgrounds.Length; ++ i )
		{
			float offset = x * backgrounds[i].speed;
			backgrounds[i].background.material.mainTextureOffset = new Vector2(offset, 0);
		}
	}
}


