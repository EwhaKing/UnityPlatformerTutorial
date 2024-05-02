using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    private MovementRigidbody2D movement;

    //�÷��̾ �̵��� �� �� �ؿ� ������ ����Ʈ
    [SerializeField]
    private ParticleSystem footStepEffect;
    private ParticleSystem.EmissionModule footEmission;

    //�÷��̾ ���߿��� �ٴ����� ������ �� ������ ����Ʈ
    [SerializeField]
    private ParticleSystem landingEffect;
    private bool wasOnGround;

    private void Awake()
    {
        movement = GetComponentInParent<MovementRigidbody2D>();
        footEmission = footStepEffect.emission;
    }

    private void Update()
    {
        // �÷��̾ �ٴ��� ��� �ְ�, ��/�� �̵��ӵ��� 0�� �ƴϸ�
        if (movement.IsGrounded && movement.Velocity.x != 0)
        {
            footEmission.rateOverTime = 30;
        }
        else
        {
            footEmission.rateOverTime = 0;
        }

        // �ٷ� ���� �����ӿ� ���߿� �־���, �̹� �����ӿ� �ٴ��� ��� �ְ�,
        // y �ӷ��� 0 ������ �� �ٴڿ� "����"�� �Ǵ��ϰ� ����Ʈ ���
        if(!wasOnGround && movement.IsGrounded && movement.Velocity.y <= 0)
        {
            //��ܰ� ���� ������ ���� �ð� �ȿ� ���� �� ����� ���� �ֱ� ������ landingEffect.Stop()���� ������ ������� ��ƼŬ ����
            landingEffect.Stop();
            landingEffect.Play();
        }

        //���߿��� �ٴ����� ������ ������ 1ȸ�� ȣ���ϱ� ������ �ٷ� ���� �����ӿ� ���߿� �־������� �Ǵ��ϱ� ���� 
        //movement.IsGrounded�� wasOnGround ������ ����
        wasOnGround = movement.IsGrounded;  
    }
}
