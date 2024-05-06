using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour
{
    private ParticleSystem particle; //Particle 재생 여부 확인을 위한 변수 선언

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();

    }
    private void Update()
    {
        //파티클이 재생중인지 확인한다.
        //파티클이 재생중이 안료되었다면 파티클 본인을 삭제한다.
        if (!particle.isPlaying)
        {
            Destroy(gameObject);
        }

    }
}
