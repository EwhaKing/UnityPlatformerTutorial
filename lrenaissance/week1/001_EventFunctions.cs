using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Awake()//obj cmp 꺼져있어도 실행됨
    {
        Debug.Log("awake executed");
        Debug.Log("hello world");
    }

    private void Start()//게임 obj, cmp 모두 활성화 되어있을 때 1회 호출
    {
        Debug.Log("start executed");
    }

    private void OnEnable()//cmp 비활성화 되었다가 활성화 될 때마다 1회 호출
    {
        Debug.Log("onEnable executed");
    }

    private void Update()//cmp 활성화되어 있을 때 매 프레임마다 호출
    {
        Debug.Log("update executed");
    }

    private void LateUpdate()//현 씬의 모든 obj의 update()가 1회 실행된 후 실행됨
    {
        Debug.Log("lateUpdate executed");
    }

    private void FixedUpdate()//프레임 영향 받는 앞의 두 update 함수와는 달리 프레임 영향x, 일정 간격 호출
    {
        Debug.Log("fixedUpdate executed");
    }

    private void OnDestroy()//obj 파괴시 1회 호출(씬 변경. 게임 종료)
    {
        Debug.Log("onDestroy executed");
    }

    private void OnApplicationQuit()//게임 종료 시 1회 호출
        Debug.Log("onAppQuit executed");
    }

    private void OnDisablet()//cmp 활->비활일 때마다 1회 호출
        Debug.Log("onDisable executed");
    }
}
