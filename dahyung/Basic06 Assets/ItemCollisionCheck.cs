using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionCheck : MonoBehaviour
{
    private void onTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
