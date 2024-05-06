using System.Collections;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField]
    private bool canBounce = false; // Bounce ���� ����
    private float startPositionY; //Ÿ���� ���� y ��ġ

    //Ÿ�ϰ� �÷��̾ �浹�ߴ��� üũ (�����ð����� �ٽ� �浹üũ�� ���� �ʵ���)
    public bool IsHit { private set; get; } = false;

    private void Awake()
    {
        startPositionY = transform.position.y;
    }

    //UpdateCollision()�� ���� �޼ҵ��̱� ������, �� TileBase�� ��ӹ޴� �ڽ� Ŭ�������� override(������)�ؼ� ����� ���� �ְ�,
    //TileBase�� �ִ� UpdateCollision()�� ȣ���� ���� �ִ�. 
    public virtual void UpdateCollision()
    {
       if(canBounce == true)
        {
            IsHit = true;   

            StartCoroutine(nameof(OnBounce));   
        }
    }


    private IEnumerator OnBounce()
    {
        float maxBounceAmount = 0.35f;

        //�ڷ�ƾ �޼ҵ� ���ο��� yield return���� �ٸ� �ڷ�ƾ �޼ҵ带 �����ϸ� �ش� �ڷ�ƾ �޼ҵ� ������ ����� ���� �Ʒ��� �ִ� �ڵ�� �Ѿ
        //Ÿ���� ���� y��ġ���� 0.35��ŭ ���� �ö󰡵��� MoveToY �ڷ�ƾ �޼ҵ带 ����
        yield return StartCoroutine(MoveToY(startPositionY, startPositionY+maxBounceAmount));

        //�̵��� �Ϸ�Ǹ� �ö� ��ġ���� �ٽ� Ÿ���� ���� y ��ġ���� �Ʒ��� �������� MoveToY() �ڷ�ƾ �޼ҵ� ����
        yield return StartCoroutine(MoveToY(startPositionY + maxBounceAmount, startPositionY));

        IsHit = false;
    }

    private IEnumerator MoveToY(float start, float end)
    {
        float percent = 0;
        float bounceTime = 0;

        while(percent < 1)
        {
            percent += Time.deltaTime / bounceTime;

            Vector3 position = transform.position;  
            position.y = Mathf.Lerp(start, end, percent);
            transform.position = position;

            yield return null;  
        }
    }
}
