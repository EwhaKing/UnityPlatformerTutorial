using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField]
    Color color;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        spriteRenderer.color = color;
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(gameObject.name + " : OnCollisionStay2D() 메소드 실행");
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        spriteRenderer.color = Color.white;

    }
}
