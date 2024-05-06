using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.C;

    private MovementRigidbody2D movement;
    private PlayerAnimator playerAnimator;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update()
    {
        // Ű �Է� (��/�� ���� Ű, xŰ)
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f;

        // �ȱ��� �� ���� ������ -0.5~0.5
        // �ٱ��� �� ���� ������ -1~1�� ����
        x*= offset; 

        //�÷��̾��� �̵� ���� (��/��)
        UpdateMove(x);
        //�÷��̾��� ���� ����
        UpdateJump();  
        //�÷��̾� �ִϸ��̼� ���
        playerAnimator.UpdateAnimation(x);
        //�Ӹ�/�߿� �浹�� ������Ʈ ó��
        UpdateAboveCollision();
        UpdateBelowCollision();
    }

    private void UpdateMove(float x)
    {
        //�÷��̾��� ������ �̵� (��/��)
        movement.MoveTo(x);

        //�÷��̾��� x�� �̵� �Ѱ�ġ ���� (PlayerLimitMinX ~ PlayerLimitMaxX)
        float xPosition = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMinX, stageData.PlayerLimitMaxX);
        transform.position = new Vector2(xPosition, transform.position.y);
    }

    private void UpdateJump()
    {
        if( Input.GetKeyDown(jumpKeyCode) )
        {
            movement.Jump();
        }

        if(Input.GetKey(jumpKeyCode) )
        {
            movement.IsLongJump = true;
        }
        else if (Input.GetKeyUp(jumpKeyCode) )
        {
            movement.IsLongJump = false;
        }
    }

    private void UpdateAboveCollision()
    {
        if(movement.Velocity.y >= 0  && movement.HitAboveObject != null){
            //�÷��̾��� �Ӹ��� ������Ʈ�� �浹�߱� ������ y�� �ӷ��� 0���� ����
            movement.ResetVelocityY();

            //�÷��̾��� �Ӹ��� �浹�� ������Ʈ�� Tile�� �� Tile�� �Ӽ��� ���� �浹 ó��
            //GetComponent<>()�� ������Ʈ�� ������, ������Ʈ�� ���������� ���Դ���
            //null üũ�� �ؼ� null�� �ƴ� �� � ó���� �ϴ� �ڵ��� ��� TryGetComponent<>() Ȱ��

            //TryGetComponent<>() �� movement.HitAboveObject�� 
            //TileBase ������Ʈ�� �ִ��� �˻��ϰ�, ������Ʈ�� ������ out var tile ������
            //������Ʈ ������ ������ �� true�� ��ȯ�� ���ǹ� ���� �ڵ带 ����

            if(movement.HitAboveObject.TryGetComponent<TileBase>(out var tile) && !tile.IsHit)
            {
                tile.UpdateCollision();
            }
        }
    }

    private void UpdateBelowCollision()
    {
        if(movement.HitBelowObject != null) {

            //Platform_03_OneWay
            if(Input.GetKeyDown(KeyCode.DownArrow)&&movement.HitBelowObject.TryGetComponent<PlatformEffectorExtension>(out var p))
            {
                p.OnDownWay();
            }
            if(movement.HitBelowObject.TryGetComponent<PlatformBase>(out var platform))
            {
                platform.UpdateCollision(gameObject);
            }
        }
    }
}
