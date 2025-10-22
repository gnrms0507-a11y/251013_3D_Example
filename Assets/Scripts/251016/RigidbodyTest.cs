using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{
    private Rigidbody _rigidyBody; // Rigidbody ����
    [SerializeField] private float _force; // ������Ʈ���� ������ ��
    [SerializeField] private float _velocityValue;  //Velocity(������)�� ��ȭ�ϱ� ���� ����


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _rigidyBody = GetComponent<Rigidbody>();
    }

    //ZŰ�� ������ Velocity�� ���࿡ ���� ��ġ�� �ʱ�ȭ
    //angularVelocity �� ȸ����
    private void Update()
    {
        //�������� �������� ,  ForceMode.Impulse �� ���������� ���Ը� �����Ѵ�
        if (Input.GetKeyDown(KeyCode.S))
        {
            //_rigidyBody.AddForce(Vector3.up * _force,ForceMode.Impulse); // ���� ���� �ش�

            //_rigidyBody.AddTorque(Vector3.up * _force); // y����� ȸ������ �����Ѵ�

            //_rigidyBody.velocity = Vector3.up * _velocityValue; //velocity�� ������ ���� ��Ȯ�Ѽ�ġ�� �����Ҽ������� ����

            _rigidyBody.angularVelocity = Vector3.up * _velocityValue;  //ȸ���µ� ��Ȯ�Ѽ�ġ�� ����������

        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            _rigidyBody.velocity = Vector3.zero;
            _rigidyBody.angularVelocity = Vector3.zero;
        }
    }

}
