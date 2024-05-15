using System.Collections;
using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private bool onlyDeactive = true;
    [SerializeField]
    private float destroyTime = 5;

    private IEnumerator Start()
    {
        while( destroyTime > 0)
        {
            destroyTime -= Time.deltaTime;  

            yield return null;  
        }

        if( onlyDeactive)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
