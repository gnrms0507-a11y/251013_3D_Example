using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    //해당 오브젝트가 이동할 속도 설정
    [SerializeField] private float _moveSpeed;

    //내가 지금 웨이포인트 중 어디에 와있는가
    private int _currentTargetIndex = 0;
    //웨이포인트들 담아둔 프랜스폼 -> 자식들이 웨이포인트이니까 얘를 통해 웨이포인트 접근 가능할 것임
    private Transform _wayPointBox;

    //얘를 소환해줄 외부 클래스가 호출할 수 있는, 웨이포인트 설정 함수

    public void SetWayPointBox(Transform waypointBox)
    {
        _wayPointBox = waypointBox;
    }

    //충돌 체크를 통한 웨이프인트 이동
    private void OnTriggerEnter(Collider other)
    {
        //웨이포인트에 접근한게 맞는지 확인
        if (other.CompareTag("WaypointChecker"))
        {
            //안전을 위한 예외처리
            if (_wayPointBox == null)
                return;

            //타겟 이동
            _currentTargetIndex += 1;

            //자식의 수보다 인덱스 값이 높아지지 않도록 처리
            if (_currentTargetIndex >= _wayPointBox.childCount)
                _currentTargetIndex = 0;
        }
    }

    private void Update()
    {
        MoveObj();
    }

    //웨이포인트 이동 함수
    private void MoveObj()
    {
        //이동지점에 대한 정보가 없다면 이동하지 말자
        if (_wayPointBox == null)
            return;

        //현재 가고자 하는 지점의 정보를 가져오자
        Transform targetTrf = _wayPointBox.GetChild(_currentTargetIndex);

        //위 정보를 바탕으로 이동해야할 방향을 계산하자
        Vector3 direction = (targetTrf.position - transform.position).normalized;

        //계산된 방향으로 이동하자
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }
}