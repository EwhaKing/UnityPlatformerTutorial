using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctionsTest : MonoBehaviour
{

    // Awake() : 현재 씬에서 게임오브젝트가 활성화 되어있을 때 1회 호출
    //                   컴포넌트가 비활성화 상태여도 게임오브젝트가 활성화 되어있으면 호출됨
    //                   데이터 초기화 용도로 사용함
    private void Awake()
    {
        Debug.Log("Awake 함수 실행");
    }


    // Start() : Awake()와 비슷하지만, 첫 번째 업데이트 함수가 실행되기 직전에 호출
    // 초기화 함수 호출 순서 Awake() -> OnEnable() -> Start()
    private void Start()
    {
        Debug.Log("Start 함수 실행");
    }

    // OnEnable() : 컴포넌트가 비활성화 되었다가 활성화 될 때 1회 호출
    private void OnEnable()
    {
        Debug.Log("OnEnable 함수 실행");
    }

    // Update() : 현재 씬이 실행된 후 컴포넌트가 활성화되어 있을 때 매 프레임마다 호출
    // FPS 60 뜻 : Update()가 1초에 60번 호출된다는 뜻
    private void Update()
    {
        Debug.Log("Update 함수 실행");
    }

    // LateUpdate() : 현재 씬에 존재하는 모든 Update() 함수가 1회 실행된 후 호출
    // 호출 순서 : Update() -> LateUpdate()
    private void LateUpdate()
    {
        Debug.Log("LateUpdate 함수 실행");
    }

    // FixedUpdate() : 프레임의 영향을 받지 않고 일정한 간격으로 호출, Default 0.02
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 함수 실행");
    }

    // OnDestroy() : 게임오브젝트가 파괴될 때 1회 호출
    // 씬이 변경되거나 게임이 종료될 때도 오브젝트가 파괴되기 때문에 호출됨
    private void OnDestroy()
    {
        Debug.Log("OnDestroy 함수 실행");
    }

    // OnApplicationQuit() : 게임이 종료될 때 1회 호출
    // Unity Editor에서는 플레이 모드 중지할 때 호출됨
    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit 함수 실행");
    }

    // OnDisable() : 컴포넌트가 활성화 되었다가 비활성화 될 때마다 1회 호출 (OnEnable과 반대)
    private void OnDisable()
    {
        Debug.Log("OnDisable 함수 실행");
    }
}
