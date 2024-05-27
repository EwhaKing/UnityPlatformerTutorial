using UnityEngine;

// Ŭ���� ��ܿ� �� ��Ʈ����Ʈ�� �ۼ��ϸ� Project View�� ����("+") �޴��� �̿��� ���� ������ ������ �� �ִ�
[CreateAssetMenu]

//�θ� Ŭ������ ScriptableObject�� ����ϸ� �ش� Ŭ������ ����(����)�� ���·� ������ �� ����
public class StageData : ScriptableObject
{
    [Header("Camera Limit")]
    [SerializeField]
    private float cameraLimitMinX;
    [SerializeField] 
    private float cameraLimitMaxX;

    [Header("Player Limit")]
    [SerializeField]
    private float playerLimitMinX;
    [SerializeField] 
    private float playerLimitMaxX;

    [Header("Map Limit")]
    [SerializeField]
    private float mapLimitMinY;

    [Header("Start Position")]
    [SerializeField]
    private Vector2 playerPosition;
    [SerializeField]
    private Vector2 cameraPosition;

    //�ܺο��� ���� �����Ϳ� �����ϱ� ���� ������Ƽ Get
    public float CameraLimitMinX => cameraLimitMinX;
    public float CameraLimitMaxX => cameraLimitMaxX;
    public float PlayerLimitMinX => playerLimitMinX;
    public float PlayerLimitMaxX => playerLimitMaxX;
    public float MapLimitMinY => mapLimitMinY;
    public Vector2 PlayerPosition => playerPosition;
    public Vector2 CameraPosition => cameraPosition;    
}
