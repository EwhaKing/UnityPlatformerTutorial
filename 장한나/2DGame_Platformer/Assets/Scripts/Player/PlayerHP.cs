using System.Collections;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private UIPlayerData uiPlayerData;
    
    [SerializeField]
    private int max = 3;  //�ִ� ü��
    [SerializeField]
    private int current; //���� ü��

    private SpriteRenderer spriteRenderer; //�÷��̾� �ǰ� �� ���� ������ ����
    private Color originColor; //�÷��̾��� �ʱ� ����

    [SerializeField]
    private float invincibilityTime = 0;    //���� ���ӽð�
    private bool isInvincibility = false; //���� ����

    private void Awake()
    {
        current = max;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originColor = spriteRenderer.color;
    }

    public void DecreaseHP()
    {
        //���� ������ ���� ü���� �������� �ʴ´�
        if (isInvincibility == true) return;

        //ü���� �����ϸ� �����ð����� ���� ����
        OnInvincibility(1);

        if (current > 1)
        {
            current--;
            uiPlayerData.SetHP(current, false);
        }
        else
        {
            Debug.Log("�÷��̾� ��� ó��");
        }
    }

    public void IncreaseHP()
    {
        if (current < max)
        {
            uiPlayerData.SetHP(current, true);
            current++;  
        }
    }

    public void OnInvincibility(float time)
    {
        if (isInvincibility == true)
        {
            invincibilityTime += time;
        }
        else
        {
            invincibilityTime = time;
            StartCoroutine(nameof(Invincibility));
        }
    }

    private IEnumerator Invincibility()
    {
        isInvincibility = true;
        float blinkSpeed = 10;

        while (invincibilityTime > 0)
        {
            invincibilityTime -= Time.deltaTime;

            Color color = spriteRenderer.color;
            color.a = Mathf.SmoothStep(0, 1, Mathf.PingPong(Time.time * blinkSpeed, 1));
            spriteRenderer.color = color;

            yield return null;
        }

        spriteRenderer.color = originColor;
        isInvincibility = false;
    }

}
