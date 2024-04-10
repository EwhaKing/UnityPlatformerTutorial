using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCodeFire = KeyCode.Space;
    [SerializeField]
    private GameObject bulletPrefab;
    private float movespeed = 3.0f;
    private Vector3 lastMoveDirection = Vector3.right; // �������� �߻�ƴ� ����

    private void Update()
    {
        // �÷��̾� ������Ʈ �̵�
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * movespeed * Time.deltaTime;

        // �������� �Էµ� ����Ű�� ������ �Ѿ��� �߻� �������� Ȱ��
        if (x != 0 || y != 0) // ���ڸ��� ���� �ʴ� ��, ��� �������� �������簣��
        {
            lastMoveDirection = new Vector3(x, y, 0); // ������ ���� ����
        }


        // �÷��̾� ������Ʈ �Ѿ� �߻� ( ���� ���ӿ� Ȱ�� ����)
        if (Input.GetKeyDown(keyCodeFire))
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // ������ ������Ʈ ����
            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;

            // ���� ���� (��� �ű��ؿ�)
            clone.GetComponent<Movement2D_2>().Setup(lastMoveDirection);
        }
    }
}
