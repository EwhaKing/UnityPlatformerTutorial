using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctionsTest : MonoBehaviour
{

    // Awake() : ���� ������ ���ӿ�����Ʈ�� Ȱ��ȭ �Ǿ����� �� 1ȸ ȣ��
    //                   ������Ʈ�� ��Ȱ��ȭ ���¿��� ���ӿ�����Ʈ�� Ȱ��ȭ �Ǿ������� ȣ���
    //                   ������ �ʱ�ȭ �뵵�� �����
    private void Awake()
    {
        Debug.Log("Awake �Լ� ����");
    }


    // Start() : Awake()�� ���������, ù ��° ������Ʈ �Լ��� ����Ǳ� ������ ȣ��
    // �ʱ�ȭ �Լ� ȣ�� ���� Awake() -> OnEnable() -> Start()
    private void Start()
    {
        Debug.Log("Start �Լ� ����");
    }

    // OnEnable() : ������Ʈ�� ��Ȱ��ȭ �Ǿ��ٰ� Ȱ��ȭ �� �� 1ȸ ȣ��
    private void OnEnable()
    {
        Debug.Log("OnEnable �Լ� ����");
    }

    // Update() : ���� ���� ����� �� ������Ʈ�� Ȱ��ȭ�Ǿ� ���� �� �� �����Ӹ��� ȣ��
    // FPS 60 �� : Update()�� 1�ʿ� 60�� ȣ��ȴٴ� ��
    private void Update()
    {
        Debug.Log("Update �Լ� ����");
    }

    // LateUpdate() : ���� ���� �����ϴ� ��� Update() �Լ��� 1ȸ ����� �� ȣ��
    // ȣ�� ���� : Update() -> LateUpdate()
    private void LateUpdate()
    {
        Debug.Log("LateUpdate �Լ� ����");
    }

    // FixedUpdate() : �������� ������ ���� �ʰ� ������ �������� ȣ��, Default 0.02
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate �Լ� ����");
    }

    // OnDestroy() : ���ӿ�����Ʈ�� �ı��� �� 1ȸ ȣ��
    // ���� ����ǰų� ������ ����� ���� ������Ʈ�� �ı��Ǳ� ������ ȣ���
    private void OnDestroy()
    {
        Debug.Log("OnDestroy �Լ� ����");
    }

    // OnApplicationQuit() : ������ ����� �� 1ȸ ȣ��
    // Unity Editor������ �÷��� ��� ������ �� ȣ���
    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit �Լ� ����");
    }

    // OnDisable() : ������Ʈ�� Ȱ��ȭ �Ǿ��ٰ� ��Ȱ��ȭ �� ������ 1ȸ ȣ�� (OnEnable�� �ݴ�)
    private void OnDisable()
    {
        Debug.Log("OnDisable �Լ� ����");
    }
}
