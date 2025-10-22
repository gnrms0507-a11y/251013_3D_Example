using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowerdTest : MonoBehaviour
{
    //이동할 대상의 위치
    [SerializeField] private Transform _targetTrf;


    [SerializeField][Range(0, 1)] private float _moveSpeed;


    private void Update()
    {
        MoveObj();
    }
    private void MoveObj()
    {

        //타겟이 없을때 리턴하여 종료
        if (_targetTrf == null)
            return;

        
        transform.position = Vector3.MoveTowards(
            transform.position, //자신의 위치
            _targetTrf.position, //타겟의 위치
            _moveSpeed * Time.deltaTime //이동속도
            );
    }
}
