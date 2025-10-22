using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTest : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    //Time.DeltaTime �� ? �����ӻ����� �ð�(����) ex) 30�������̶�� 30/1 �� ��ŸŸ�� * �����Ӽ� ==1

    private void Update()
    {
        MoveObj();
    }
    private void MoveObj()
    {
        //���� ��ġ�� -> ����3������ * �̵��ӵ� * ��ŸŸ��
        transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;
    }

}
