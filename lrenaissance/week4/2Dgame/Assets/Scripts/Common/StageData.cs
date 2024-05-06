using UnityEngine;

[CreateAssetMenu]
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

    //외부에서 변수 데이터에 접근하기 위한 프로퍼티 get
    public float CameraLimitMinX => cameraLimitMinX;
    public float CameraLimitMaxX=>cameraLimitMaxX;
    public float PlayerLimitMinX => playerLimitMinX;
    public float PlayerLimitMaxX => playerLimitMaxX;
    public float MapLimitMinY => mapLimitMinY;
}
