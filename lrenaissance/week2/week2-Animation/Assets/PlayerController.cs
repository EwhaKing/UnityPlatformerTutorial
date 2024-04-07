using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
 
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//space 누르면 죽음
        {
            animator.SetTrigger("isDie");//isDie 체크되어서 활성화
        }
    }

    public void OnDieEvent()//public이어야 animation에서 호출 가능
    {
        Debug.Log("End of Die Animation");
    }
}
