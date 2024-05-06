using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private void Awake()
    {
        // playerObject 게임오브젝트의 "PlayerController"컴포넌트 삭제
        //Destroy(playerObject.GetComponent<PlayerController>());

        // playerObject 게임오브젝트를 삭제
        //Destroy(playerObject);

        // playerObject 게임오브젝트를 2초 뒤에 삭제
        //Destroy(GameObject, time); 게임오브젝트를 time 시간만큼 흐른 뒤에 삭제
        Destroy(playerObject,2.0f);
    }
}
