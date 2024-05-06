using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_3 : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isDie");
        }
    }

    public void OnDie()
    {//public으로 해야 애니메이션에서 함수 호출 가능
        Debug.Log("End of Die Animation");
    }
}
