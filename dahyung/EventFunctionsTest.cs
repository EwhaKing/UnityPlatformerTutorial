using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctionsTest : MonoBehaviour
{
    private void Awake() {
        Debug.Log("Awake함수가 실행되었습니다.");
    }

    private void Start() {
        Debug.Log("Start함수가 실행되었습니다.");
    }

    private void OnEnable() {
        Debug.Log("OnEnable함수가 실행되었습니다.");
    }

    private void Update() {
        Debug.Log("Update 함수가 실행되었습니다.");
    }

    private void LateUpdate() {
        Debug.Log("LateUpdate 함수가 실행되었습니다.");
    }

    private void FixedUpdate() {
        Debug.Log("FixedUpdate함수가 실행되었습니다.");
    }

    private void OnDestroy() {
        Debug.Log("OnDestroy함수가 실행되었습니다.");
    }

    private void OnApplicationQuit() {
        Debug.Log("OnApplicationQuit함수가 실행되었습니다.");
    }

    private void OnDissable() {
        Debug.Log("OnDissable함수가 실행되었습니다.");
    }





}
