using UnityEngine;

// 클래스 상단에 이 어트리뷰트를 작성하면 Project View의 생성("+") 메뉴를 이용해 에셋 파일을 생성할 수 있다
[CreateAssetMenu]

//부모 클래스로 ScriptableObject를 사용하면 해당 클래스를 에셋(파일)의 형태로 저장할 수 있음
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

    //외부에서 변수 데이터에 접근하기 위한 프로퍼티 Get
    public float CameraLimitMinX => cameraLimitMinX;
    public float CameraLimitMaxX => cameraLimitMaxX;
    public float PlayerLimitMinX => playerLimitMinX;
    public float PlayerLimitMaxX => playerLimitMaxX;
    public float MapLimitMinY => mapLimitMinY;
    public Vector2 PlayerPosition => playerPosition;
    public Vector2 CameraPosition => cameraPosition;    
}
