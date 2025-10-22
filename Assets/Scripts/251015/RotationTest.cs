using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    //오브젝트의 회전

    //회전속도 지정
    [SerializeField] private float _rotateSpeed;


    private void Update()
    {
        RotateObj();
    }

    private void RotateObj()
    {
        //y축을 회전시킬것이므로 y축에 움직이는 스피드 + 델타타임을 곱함
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x, //x축 그대로
            transform.rotation.eulerAngles.y + _rotateSpeed * Time.deltaTime, //y축은 회전속도를 더함
            transform.rotation.z //z축 그대로
            );
    }
}
