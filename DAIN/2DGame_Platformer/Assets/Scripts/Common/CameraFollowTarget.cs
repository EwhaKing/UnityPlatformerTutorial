using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
	[SerializeField]
	private	StageData	stageData;
	[SerializeField]
	private	Transform	target;
	[SerializeField]
	private bool x, y, z;

	private float offsetY;

	private void Awake()
	{
		// (카메라의 y 위치 - target의 y위치) 값을 절대값으로 변환하고, offsetY 변수에 저장
		offsetY = Mathf.Abs(transform.position.y - target.position.y);
	}

	private void LateUpdate()
	{
		// 값이 true인 축만 target의 좌표를 따라가도록 설정
		transform.position = new Vector3((x ? target.position.x : transform.position.x),
										 (y ? target.position.y + offsetY : transform.position.y),
										 (z ? target.position.z : transform.position.z));

		// 카메라의 좌/우측 이동 범위를 넘어가지 않도록 설정 : 카메라 x 위치 설정
		Vector3 position = transform.position;
		position.x = Mathf.Clamp(transform.position.x, stageData.CameraLimitMinX, stageData.CameraLimitMaxX);
        // float result = Mathf.Clamp(float value, float min, float max);
        // value < min		result = min
		// value > max		result = max
		// min < value && value < max		result = value
        transform.position = position;
	}
}

