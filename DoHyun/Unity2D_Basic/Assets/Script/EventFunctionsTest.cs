using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctionsTest : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake 함수 실행");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start 함수 실행");

    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 함수 실행");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update 함수 실행");

    }
    private void LateUpdate()
    {
        Debug.Log("LateUpdate 함수 실행");

    }
    private void FixedUpdate()
    {

        Debug.Log("FixedUpdate 함수 실행");
    }

    private void OnDestroy()
    {

        Debug.Log("오브젝트 파괴");
    }

    private void OnApplicationQuit()
    {

        Debug.Log("OnApplicationQuit 실행");
    }
    private void OnDisable()
    {

        Debug.Log("OnDisable 함수 실행");
    }

}
