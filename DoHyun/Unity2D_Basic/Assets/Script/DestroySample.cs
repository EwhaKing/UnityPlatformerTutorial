using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySample : MonoBehaviour
{
    //Destroy() : 오브젝트 삭제 함수로 매개변수에 입력되어 있는 오브젝트 Or 컴포넌트를 삭제한다.
    //오브젝트가 게임에서 영구적으로 사라져야 할 때 Destroy() 함수를 이용해 삭제하게 된다.
    //컴포넌트도 삭제 가능 하다.


    [SerializeField]
    private GameObject playerObject;

    private void Awake()
    {
        //playerObject 게임오브젝트의 PlayerController 컴포넌트 삭제
        //Destroy(playerObject.GetComponent<PlayerController>());

        //playerObject 게임오브젝트 삭제
        //Destroy(playerObject);


        //게임 오브젝트를 time 시간만큼 흐른 뒤에 삭제
        //Deatroy(GameObject, time);
        Destroy(playerObject, 2.0f);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
