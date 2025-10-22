using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{
    private Rigidbody _rigidyBody; // Rigidbody 참조
    [SerializeField] private float _force; // 오브젝트에게 가해질 힘
    [SerializeField] private float _velocityValue;  //Velocity(물리력)를 변화하기 위한 변수


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _rigidyBody = GetComponent<Rigidbody>();
    }

    //Z키를 누르면 Velocity와 각축에 대한 수치를 초기화
    //angularVelocity 는 회전력
    private void Update()
    {
        //위쪽으로 힘을가함 ,  ForceMode.Impulse 는 힘의종류임 무게를 적용한다
        if (Input.GetKeyDown(KeyCode.S))
        {
            //_rigidyBody.AddForce(Vector3.up * _force,ForceMode.Impulse); // 위로 힘을 준다

            //_rigidyBody.AddTorque(Vector3.up * _force); // y축기준 회전력을 증감한다

            //_rigidyBody.velocity = Vector3.up * _velocityValue; //velocity를 조절해 힘을 정확한수치로 제어할수도있음 띄우기

            _rigidyBody.angularVelocity = Vector3.up * _velocityValue;  //회전력도 정확한수치로 지정가능함

        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            _rigidyBody.velocity = Vector3.zero;
            _rigidyBody.angularVelocity = Vector3.zero;
        }
    }

}
