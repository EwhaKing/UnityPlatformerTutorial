using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private void Awake()
    {
        // playerObject 게임오브젝트의 "playerController" 컴포넌트 삭제
        // Destroy(playerObject.GetComponent<PlayerController>());

        // 아예 삭제하는 것보다는 꺼두는 것을 권장
        // playerObject.GetComponent<PalyerController>().enabled = false;

        // playerObject 게임 오브젝트를 삭제
        // Destroy(playerObject);

        // playerObject 게임오브젝트를 2초 뒤에 삭제
        Destroy(playerObject, 2.0f);
    }
}
