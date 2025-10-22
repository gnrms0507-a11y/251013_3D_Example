using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTest : MonoBehaviour
{

    //특정 지점을 축으로 오브젝트를 회전시키는 기능

    //축이 될 지점에 대한 대상을 참조
    [SerializeField] private Transform target;
    //회전속도
    [SerializeField] private float _rotateSpeed;


    private void Update()
    {
        RotateObj();
    }
    private void RotateObj()
    {
        transform.RotateAround(

            target.position,    //대상의 지점
            Vector3.up, //회전축
            _rotateSpeed * Time.deltaTime   //회전속도
            );
    }


}
