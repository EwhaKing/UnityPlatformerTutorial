using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private void Awake()
    {
        // playerObject 게임 오브젝트의 "PlayerController" 컴포넌트 삭제
        // Destroy(playerObject.GetComponent<PlayerController>());

        // 위 처럼 컴포넌트 삭제 가능하지만 아래처럼 삭제말고 꺼두는 걸 권장함
        playerObject.GetComponent<PlayerController>().enabled = false;

        // playerObject 게임 오브젝트 삭제
        // Destroy(playerObject);

        // playerObject 게임 오브젝트를 2초 뒤에 삭제
        Destroy(playerObject, 2.0f);
    }
}
