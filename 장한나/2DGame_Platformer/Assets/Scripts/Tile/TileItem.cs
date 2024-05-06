using UnityEngine;

public class TileItem : TileBase
{
    [Header("Tile Item")]
    [SerializeField]
    private ItemType itemType = ItemType.Random; //������ �Ӽ�
    [SerializeField]
    private GameObject[] itemPrefabs; //������ Ÿ�ϰ� ��ȣ�ۿ� ���� �� �����Ǵ� ������ �����յ�
    [SerializeField]
    private int coinCount; //�������� �Ӽ��� ������ �� ���� ����
    [SerializeField]
    private Sprite nonBrokeImage; //������ Ÿ���� ��� �������� �����Ǿ��� �� ��µǴ� �̹���

    private bool isEmpty = false;   //������ Ÿ���� ����ִ��� ����

    public override void UpdateCollision()
    {
        //�������� ��������� NonBroke�� �����ϰ� ��ȣ�ۿ� ����
        if (isEmpty == true) return;

        //�θ� Ŭ������ TileBase�� �ִ� UpdateCollision() �޼ҵ� ȣ�� (Bounce)
        base.UpdateCollision();
        // ������ ����
        SpawnItem();
    }

    private void SpawnItem()
    {
        if(itemType == ItemType.Random)
        {
            itemType = (ItemType)Random.Range(0, itemPrefabs.Length);
        }

        Instantiate(itemPrefabs[(int)itemType], transform.position, Quaternion.identity);

        if( itemType == ItemType.Coin)
        {
            coinCount--;
        }
        //�������� �Ӽ��� ����(itemType.Coin)�� �ƴϰų� ���� �� �� ���� ������ 0�̸�
        if( itemType != ItemType.Coin || (itemType == ItemType.Coin && coinCount==0))
        {
            GetComponent<SpriteRenderer>().sprite = nonBrokeImage; //������ Ÿ���� �̹����� �� Ÿ�Ϸ� ����
            isEmpty = true; //������ Ÿ���� ����������� ����
        }
    }

}
