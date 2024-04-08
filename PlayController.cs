using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<animator>();
    }
    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isDie");
            //animator.SetBool();
            //animator.SetFloat();
        }
    }

    public void OnDieEvent()
    {
        Debug.Log("End of Die Animation");
    }
}