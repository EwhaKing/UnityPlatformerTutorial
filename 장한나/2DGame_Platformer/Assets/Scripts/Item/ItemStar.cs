using UnityEngine;

public class ItemStar : ItemBase
{
    [Tooltip("�� �������� �� �ʿ� �׻� 3���� ��ġ�ϰ�, 0, 1, 2 ���� �ο�")]
    [SerializeField][Range(0, 2)]
    private int starIndex;

    public override void UpdateCollision(Transform target)
    {
        target.GetComponent<PlayerData>().GetStar(starIndex);
    }
}
