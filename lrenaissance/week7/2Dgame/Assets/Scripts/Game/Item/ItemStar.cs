using UnityEngine;

public class ItemStar : ItemBase
{
    [Tooltip("별 아이템은 한 맴에 항상 3개를 배치하고, 0, 1, 2 순번 부여")]
    [SerializeField][Range(0,2)]
    private int starIndex;//획득한 별이 ui에 표시되는 순서
    public int StarIndex => starIndex;//별 순번 외부 열람 가능

    public override void UpdateCollision(Transform target)
    {
        target.GetComponent<PlayerData>().GetStar(starIndex);
    }
}
