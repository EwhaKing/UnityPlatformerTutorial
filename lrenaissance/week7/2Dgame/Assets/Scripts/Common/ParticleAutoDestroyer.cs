using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!particle.isPlaying) //파티클 재생 중 아님
        {
            Destroy(gameObject);
        }
    }
}
