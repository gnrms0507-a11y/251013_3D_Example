using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowerdTest : MonoBehaviour
{
    //�̵��� ����� ��ġ
    [SerializeField] private Transform _targetTrf;


    [SerializeField][Range(0, 1)] private float _moveSpeed;


    private void Update()
    {
        MoveObj();
    }
    private void MoveObj()
    {

        //Ÿ���� ������ �����Ͽ� ����
        if (_targetTrf == null)
            return;

        
        transform.position = Vector3.MoveTowards(
            transform.position, //�ڽ��� ��ġ
            _targetTrf.position, //Ÿ���� ��ġ
            _moveSpeed * Time.deltaTime //�̵��ӵ�
            );
    }
}
