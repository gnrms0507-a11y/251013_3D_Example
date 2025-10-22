using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveController : MonoBehaviour
{
    //구분용 레이어 변수 및 이동을 위한 변수들
    [SerializeField] private LayerMask _groundMask; //레이어 구분 - 원치않는 레이어 클릭 방지
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _moveSpeed;  //이속
    [SerializeField] private float _rotateSpeed; //회전속도

    private Vector3 _targetPos; //이동목표위치

    private bool _hasTarget = false; // 목표가 있을때만 기즈모 뿌림


    private void Awake()
    {
        //따로 설정한 카메라없으면 메인이 플레이어카메라가됨
        if(_playerCamera == null)
        {
            _playerCamera = Camera.main;
          
        }
        _targetPos = transform.position; //포지션도 현재위치
    }

    private void Update()
    {
        HandleMouseInput();
        MoveToTarget();
    }

    //유저의 마우스 입력을 통해 레이캐스트를 사용하고 이동할 위치를 정의해준다
    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(1))        //0 - 좌클릭 1 우클릭
        {
            Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);   //받아온 마우스위치에서 레이 발사 , 내 마우스포지션에서

            if(Physics.Raycast(ray , out RaycastHit hit , 100f , _groundMask))
            {
                _targetPos = hit.point;  // 월드기준 맞은위치 -point
                _hasTarget = true;  //목표위치가 있으니 트루로
            }
        }
    }

    private void MoveToTarget()
    {
        //목표위치 업승면 이동안해도 되니 리턴
        if (_hasTarget ==false)
        {
            return;
        }

        //이동하고자 하는 방향
        Vector3 direction = _targetPos - transform.position;  // 타겟과 현재 위치의 거리
        direction.y = 0f;
        float distance = direction.sqrMagnitude;   //거리계산에 쓰임 매그니튜드 . 점과 점사이 거리 계산


        //거리가 0.05f보다 떨어져있다면
        if(distance > 0.05f * 0.05f)
        {
            //회전
            Quaternion targetRot = Quaternion.LookRotation(direction.normalized);   //방향 바라보
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _rotateSpeed * Time.deltaTime);

            //이동
            Vector3 move = direction.normalized * _moveSpeed * Time.deltaTime;
            
            //원하는목표지점 보다 방금구한 거리가 더크다. ( 더멀리 이동한경우)
            if(move.sqrMagnitude > distance)
            {
                move = direction.normalized * distance;
            }

            transform.position += move;
        }

        else
        {
            _hasTarget = false;
        }
    }

    //이벤트함수
    //시각적 테스트용 기즈모함수 , 이동목표 위치에 구를 그려줄 예정임
    private void OnDrawGizmos()
    {
        if (_hasTarget)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_targetPos + Vector3.up * 0.3f, 1f);
        }
    }

}
