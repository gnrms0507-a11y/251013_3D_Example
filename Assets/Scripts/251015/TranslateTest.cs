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
        //PositionTest 와 내용은 같으나 함수로 변수접근하였음 Vector3.forward 는 Vector(0,0,1)임.
        //현재 위치에서 상대이동함
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
}

