using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
 
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//space ������ ����
        {
            animator.SetTrigger("isDie");//isDie üũ�Ǿ Ȱ��ȭ
        }
    }

    public void OnDieEvent()//public�̾�� animation���� ȣ�� ����
    {
        Debug.Log("End of Die Animation");
    }
}
