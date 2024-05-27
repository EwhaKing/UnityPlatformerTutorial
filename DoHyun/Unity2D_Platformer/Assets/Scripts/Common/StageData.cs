using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [Header("Camera Limit")]
    [SerializeField]
    float cameraLimitMinX; //현재 레벨에서 카메라가 갈 수 있는 최소 x 위치
    [SerializeField]
    float cameraLimitMaxX; //현재 레벨에서 카메라가 갈 수 있는 최대 x 위치

    [Header("Player Limit")]
    [SerializeField]
    float playerLimitMixX; //현재 레벨에서 플레이어가 갈 수 있는 최소 x 위치
    [SerializeField]
    float playerLimitMaxX; //현재 레벨에서 플레이어가 갈 수 있는 최대 x 위치

    [Header("Map Limit")]
    [SerializeField]
    float mapLimitMinY; //현재 레벨의 가장 아래 바닥 y 위치

    [Header("Start Position")]
    [SerializeField] private Vector2 palyerPosition;
    [SerializeField] private Vector2 cameraPosition;


    //외부에서 이 변수들을 열람할 수 있는 Get 프로퍼티를 정의
    public float CameraLimitMixX => cameraLimitMinX;
    public float CameraLimitMaxX => cameraLimitMaxX;
    public float PlayerLimitMaxX => playerLimitMaxX;
    public float PlayerLimitMixX => playerLimitMixX;
    public float MapLimitMinY => mapLimitMinY;
    public Vector2 PlayerPosition => palyerPosition;
    public Vector2 CameraPosition => cameraPosition;



}
