using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTest : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    //Time.DeltaTime 은 ? 프레임사이의 시간(간격) ex) 30프레임이라면 30/1 즉 델타타임 * 프레임수 ==1

    private void Update()
    {
        MoveObj();
    }
    private void MoveObj()
    {
        //현재 위치는 -> 벡터3앞으로 * 이동속도 * 델타타임
        transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;
    }

}
