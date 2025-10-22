using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateTest : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        MoveObj();
    }

    private void MoveObj()
    {
        //PositionTest �� ������ ������ �Լ��� ���������Ͽ��� Vector3.forward �� Vector(0,0,1)��.
        //���� ��ġ���� ����̵���
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
}

