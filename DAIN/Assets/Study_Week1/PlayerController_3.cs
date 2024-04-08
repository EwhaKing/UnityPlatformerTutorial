using UnityEngine;

public class PlayerController_3 : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("isDie"); // parameter에 접근하여 값 변경 가능
            // isDie가 지금 boolean 이기 때문에 체크(true)하게 됨
        }
    }

    // public으로 해주어야 Animation에서 이 함수를 호출할 수 있음
    public void onDieEvent()
    {
        Debug.Log("End of Die Animation");
    }
}
