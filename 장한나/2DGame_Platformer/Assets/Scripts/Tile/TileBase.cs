using System.Collections;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField]
    private bool canBounce = false; // Bounce 가능 여부
    private float startPositionY; //타일의 최초 y 위치

    //타일과 플레이어가 충돌했는지 체크 (일정시간동안 다시 충돌체크를 하지 않도록)
    public bool IsHit { private set; get; } = false;

    private void Awake()
    {
        startPositionY = transform.position.y;
    }

    //UpdateCollision()은 가상 메소드이기 때문에, 이 TileBase를 상속받는 자식 클래스에서 override(재정의)해서 사용할 수도 있고,
    //TileBase에 있는 UpdateCollision()을 호출할 수도 있다. 
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

        //코루틴 메소드 내부에서 yield return으로 다른 코루틴 메소드를 실행하면 해당 코루틴 메소드 실행이 종료된 이후 아래에 있는 코드로 넘어감
        //타일의 시작 y위치에서 0.35만큼 위로 올라가도록 MoveToY 코루틴 메소드를 실행
        yield return StartCoroutine(MoveToY(startPositionY, startPositionY+maxBounceAmount));

        //이동이 완료되면 올라간 위치에서 다시 타일의 시작 y 위치까지 아래로 내려오는 MoveToY() 코루틴 메소드 실행
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
