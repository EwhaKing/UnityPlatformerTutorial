using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject moveObjet;
    [SerializeField]
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = 5.0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        moveObjet.GetComponent<SpriteRenderer>().color = Color.black;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        moveObjet.transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        moveObjet.GetComponent<SpriteRenderer>().color = Color.white;
        moveObjet.transform.position = new Vector3(0, 4, 0);
    }
}
