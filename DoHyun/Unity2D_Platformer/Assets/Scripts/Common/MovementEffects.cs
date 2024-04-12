using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    MovementRigidbody2D movement;

    //플레이어가 이동할 때 발 밑에서 나오는 이펙트
    [SerializeField]
    private ParticleSystem footStepEffect;
    //파티클의 Emission Module을 저장하는 변수 (파티클을 생성하는 방법을 제어하는 모듈 : 언제, 어떻게 얼마나, 자주)
    ParticleSystem.EmissionModule footEmission;



    //플레이어가 공중에서 바닥으로 착지할 때 나오는 이펙트
    [SerializeField]
    ParticleSystem landingEffect;
    private bool wasOnGround;

    private void Awake()
    {
        movement = GetComponentInParent<MovementRigidbody2D>();
        // footStepEffect = GetComponent<ParticleSystem>();
        footEmission = footStepEffect.emission;
    }

    private void Update()
    {
        //플레이어가 바닥을 밟고 있고, 좌/우 이동 속력이 0이 아니라면 발 밑에서 이펙트가 나오게 한다.
        if (movement.IsGrounded && movement.Velocity.x != 0)
        {
            //rateOverTime이 30으로 30개의 파티클 입자를 주기적으로 생성해 먼지 파티클을 재생하고,
            footEmission.rateOverTime = 30;
        }

        //공중에 떠 있거나 제자리에 멈춰있으면 rateOverTime이 0으로 먼지 파티클이 생성되지 않는다.
        else
        {
            footEmission.rateOverTime = 0;
        }



        //바로 직전 프레임에 공중에 있었고, 이번 프레임에 바닥을 밟고 있고, 
        //y 속력이 0 이하일 때 바닥에 '착지'로 판단하고 이펙트 재생
        if (!wasOnGround && movement.IsGrounded && movement.Velocity.y <= 0)
        {
            //계단과 같이 착지를 빠른 시간 안에 여러 번 재생할 수도 있기 때문에
            //기존에 재생중인 파티클을 중지하고, 재생한다.
            landingEffect.Stop();
            landingEffect.Play();
        }

        wasOnGround = movement.IsGrounded; //이 부분이 중요!


    }
}
