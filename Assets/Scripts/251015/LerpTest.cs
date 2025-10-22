using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    //Ÿ�� ������Ʈ�� Ʈ������ ������
    [SerializeField] private Transform _targetTrf;

    //0 ~ 1 ���� ��ü���� �ٰ����� �ӵ�
    [SerializeField][Range(0,1)] private float _interpolate;


    private void Update()
    {
        MoveObj();
    }
    private void MoveObj()
    {

        //Ÿ���� ������ �����Ͽ� ����
        if (_targetTrf == null)
            return;

        transform.position = Vector3.Lerp(
            transform.position,
            _targetTrf.position,
            _interpolate
            );
    }

}
