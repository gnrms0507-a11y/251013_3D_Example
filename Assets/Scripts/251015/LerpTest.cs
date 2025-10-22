using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    //타겟 오브젝트의 트랜스폼 가져옴
    [SerializeField] private Transform _targetTrf;

    //0 ~ 1 사이 물체에게 다가가는 속도
    [SerializeField][Range(0,1)] private float _interpolate;


    private void Update()
    {
        MoveObj();
    }
    private void MoveObj()
    {

        //타겟이 없을때 리턴하여 종료
        if (_targetTrf == null)
            return;

        transform.position = Vector3.Lerp(
            transform.position,
            _targetTrf.position,
            _interpolate
            );
    }

}
