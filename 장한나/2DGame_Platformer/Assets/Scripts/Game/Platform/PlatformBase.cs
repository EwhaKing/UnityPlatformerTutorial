using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    //�÷����� �÷��̾ �浹�ߴ��� üũ (�����ð����� �ٽ� �浹üũ�� ���� �ʵ���)
    public bool IsHit { protected set; get; } = false;

    public abstract void UpdateCollision(GameObject other);
}
