using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Animator animator;

   private void Awake()
   {
    animator = GetComponent<Animator>();
   }

   private void Update()
   {
    if (Input.GetKeyDown(KeyCode.Space))
    {
        animator.SetTrigger("isDie");
    }
   }  

   public void OnDieEVent()
   {
    Debug.Log("End of Die Animation");
   }
}
