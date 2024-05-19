using UnityEngine;

public class RotateToAxis : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 axis=Vector3.forward;//2d일때는 일반적으로 z축만 회전하기 때문에 forward를 사용
    [SerializeField]
    private float rotateSpeed = 200;

    private void Update()
    {
        target.Rotate(axis, rotateSpeed * Time.deltaTime);//axis축으로 1초에 rotateSpeed 각도만큼 회전        
    }
}
