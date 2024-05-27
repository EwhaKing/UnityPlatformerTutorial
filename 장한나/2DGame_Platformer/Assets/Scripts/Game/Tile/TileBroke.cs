using UnityEngine;

public class TileBroke : TileBase
{
    [Header("Tile Broke")]
    [SerializeField]
    private GameObject tileBrokeEffect;

    public override void UpdateCollision()
    {
        //�θ� Ŭ������ TileBase�� �ִ� UpdateCollision() �޼ҵ� ȣ��
        base.UpdateCollision();

        // Ÿ���� �μ����� ��ƼŬ ���� (���� ��ġ��)
        Instantiate(tileBrokeEffect, transform.position, Quaternion.identity);
        
        //Ÿ�� ������Ʈ ����
        Destroy(gameObject);
    }
}
