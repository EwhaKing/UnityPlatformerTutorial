using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    [SerializeField]
    private bool x, y, z;

    private StageData stageData;
    private float offsetY;

    public void Setup(StageData stageData)
    {
        this.stageData = stageData;
        transform.position = new Vector3(stageData.CameraPosition.x, stageData.CameraPosition.y, -10);
    }

    private void Awake()
    {
          offsetY = Mathf.Abs(transform.position.y - target.position.y);
    }

    private void LateUpdate()
    {
        //true �ุ target�� ��ǥ�� ���󰡵��� ����
        transform.position = new Vector3((x ? target.position.x : transform.position.x),
                                         (y ? target.position.y + offsetY : transform.position.y),
                                         (z ? target.position.z : transform.position.z));

        //ī�޶��� ��/���� �̵� ������ �Ѿ�� �ʵ��� ����
        Vector3 position = transform.position;  
        position.x = Mathf.Clamp(transform.position.x, stageData.CameraLimitMinX, stageData.CameraLimitMaxX);
        transform.position = position;
    }
}
