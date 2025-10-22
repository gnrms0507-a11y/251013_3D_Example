using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveController : MonoBehaviour
{
    //���п� ���̾� ���� �� �̵��� ���� ������
    [SerializeField] private LayerMask _groundMask; //���̾� ���� - ��ġ�ʴ� ���̾� Ŭ�� ����
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _moveSpeed;  //�̼�
    [SerializeField] private float _rotateSpeed; //ȸ���ӵ�

    private Vector3 _targetPos; //�̵���ǥ��ġ

    private bool _hasTarget = false; // ��ǥ�� �������� ����� �Ѹ�


    private void Awake()
    {
        //���� ������ ī�޶������ ������ �÷��̾�ī�޶󰡵�
        if(_playerCamera == null)
        {
            _playerCamera = Camera.main;
          
        }
        _targetPos = transform.position; //�����ǵ� ������ġ
    }

    private void Update()
    {
        HandleMouseInput();
        MoveToTarget();
    }

    //������ ���콺 �Է��� ���� ����ĳ��Ʈ�� ����ϰ� �̵��� ��ġ�� �������ش�
    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(1))        //0 - ��Ŭ�� 1 ��Ŭ��
        {
            Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);   //�޾ƿ� ���콺��ġ���� ���� �߻� , �� ���콺�����ǿ���

            if(Physics.Raycast(ray , out RaycastHit hit , 100f , _groundMask))
            {
                _targetPos = hit.point;  // ������� ������ġ -point
                _hasTarget = true;  //��ǥ��ġ�� ������ Ʈ���
            }
        }
    }

    private void MoveToTarget()
    {
        //��ǥ��ġ ���¸� �̵����ص� �Ǵ� ����
        if (_hasTarget ==false)
        {
            return;
        }

        //�̵��ϰ��� �ϴ� ����
        Vector3 direction = _targetPos - transform.position;  // Ÿ�ٰ� ���� ��ġ�� �Ÿ�
        direction.y = 0f;
        float distance = direction.sqrMagnitude;   //�Ÿ���꿡 ���� �ű״�Ʃ�� . ���� ������ �Ÿ� ���


        //�Ÿ��� 0.05f���� �������ִٸ�
        if(distance > 0.05f * 0.05f)
        {
            //ȸ��
            Quaternion targetRot = Quaternion.LookRotation(direction.normalized);   //���� �ٶ�
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _rotateSpeed * Time.deltaTime);

            //�̵�
            Vector3 move = direction.normalized * _moveSpeed * Time.deltaTime;
            
            //���ϴ¸�ǥ���� ���� ��ݱ��� �Ÿ��� ��ũ��. ( ���ָ� �̵��Ѱ��)
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

    //�̺�Ʈ�Լ�
    //�ð��� �׽�Ʈ�� ������Լ� , �̵���ǥ ��ġ�� ���� �׷��� ������
    private void OnDrawGizmos()
    {
        if (_hasTarget)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_targetPos + Vector3.up * 0.3f, 1f);
        }
    }

}
