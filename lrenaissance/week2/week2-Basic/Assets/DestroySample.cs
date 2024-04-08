using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;

    private void Awake()
    {
        //Destroy(): 오브젝트 삭제 함수. 매개변수에 입력되어 있는 obj나 cmp 삭제
        //playerObj(게임 오브젝트)의 "PlayerCtrl" 컴포넌트 삭제
        Destroy(playerObj.GetComponent<PlayerCtrl>());

        //게임 obj 삭제
        //Destroy(playerObj);

        //2초 뒤에 obj 삭제
        Destroy(playerObj, 2.0f);
    }
}
