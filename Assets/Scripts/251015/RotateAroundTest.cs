using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTest : MonoBehaviour
{

    //Ư�� ������ ������ ������Ʈ�� ȸ����Ű�� ���

    //���� �� ������ ���� ����� ����
    [SerializeField] private Transform target;
    //ȸ���ӵ�
    [SerializeField] private float _rotateSpeed;


    private void Update()
    {
        RotateObj();
    }
    private void RotateObj()
    {
        transform.RotateAround(

            target.position,    //����� ����
            Vector3.up, //ȸ����
            _rotateSpeed * Time.deltaTime   //ȸ���ӵ�
            );
    }


}
