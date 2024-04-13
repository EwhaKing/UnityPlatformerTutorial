using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//데이터 직렬화를 위해 [System.Serializable] 어트리뷰트를 구조체 위에 선언
//배경 오브젝트마다 이동 속도가 다르기 때문에 
//배경 오브젝트의 TextureOffest 설정을 위한 Renderer 타입의 변수,
//float 타입의 이동속도 변수를 가지는
//BackgroundData 구조체를 정의한다.
[System.Serializable]
public struct BackgroundData
{
    public Renderer background;
    public float speed;

}
public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    Transform targetCamera; //배경 스크롤의 기준이 되는 카메라
    [SerializeField]
    private BackgroundData[] backgrounds; //targetCamera의 이동에 따라 스크롤되는 배경화면들을 저장하는 BackgroundData 배열 변수

    [SerializeField]
    BackgroundData backgroundCloud; //targetCamera의 이동과 관계없이 지속적으로 움직이는 구름 배경 저장

    float targetStartX; //targetCamera의 시작 x 위치


    private void Awake()
    {
        //targetCamera의 시작 위치 설정
        targetStartX = targetCamera.position.x;
    }
    private void Update()
    {
        //시간에 따라 계속 움직이는 구름 배경을 위해 cloudOffset은 시간이 흐를수록 계속 증가해야 한다.
        float cloudOffset = backgroundCloud.speed * Time.time; //Time.time은 현재 시간으로 계속 증가하기 때문에 cloudOffset이 초딩 speed만큼 증가한다.
        backgroundCloud.background.material.mainTextureOffset = new Vector2(cloudOffset, 0);

        //나머지 배경은 targetCamera의 위치에 따라 Offset이 설정되기 때문에
        //targetCamera가 null이면 코드가 실행되지 않도록 return 한다.
        if (targetCamera == null) return;


        //targetCamera의 (현재 x 위치 - 시작 x 위치) = x의 변위
        //이 x 변위와 각 배경 오브젝트의 속도를 곱해서 TextureOffset의 x 값으로 설정한다.
        float x = targetCamera.position.x - targetStartX;
        foreach (var background in backgrounds)
        {
            float offset = background.speed * x;
            background.background.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
