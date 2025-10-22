using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent))]

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private GameObject _movingPlane;
    [SerializeField] private float _moveSpeed = 20;
    [SerializeField] private float _xBoundValue = 0;
    [SerializeField] private float _zBoundValue =0;

    private InputComponent _inputComponent;
    private Vector3 _minWorldBounds;
    private Vector3 _maxWorldBounds;
    private Vector3 _playerExtents;

    private void Start()
    {
        _inputComponent = GetComponent<InputComponent>();

        SphereCollider playerColider = gameObject.GetComponent<SphereCollider>();

        if (playerColider != null)
        {
            //������Ʈ�� �ڽ��� ������ �� �ڽ��� ���������ŭ
            _playerExtents = playerColider.bounds.extents;
        }

        if (_movingPlane != null)
        {
            //Bound - ���� MeshRenderer�� ������ �����´�
            Bounds planeBounds = _movingPlane.GetComponent<MeshRenderer>().bounds;

            _minWorldBounds = planeBounds.center - planeBounds.extents;
            _maxWorldBounds = planeBounds.center + planeBounds.extents;
        }

    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        //������ �ƴϸ� ����
        if(GameManager.Instance.IsPlaying==false)
        {
            return;
        }

        //��ǲ������Ʈ�� x�ప , y��ǥ , z�ప
        Vector3 inputVec = new Vector3(_inputComponent.HorInput, 0f, _inputComponent.VerInput).normalized;

        Vector3 deltaMovement = _moveSpeed * Time.deltaTime * inputVec;
        Vector3 nextPosition = transform.position + deltaMovement;

        float xGap = _xBoundValue * _playerExtents.x;
        float zGap = _zBoundValue * _playerExtents.z;

        nextPosition.x = Mathf.Clamp(nextPosition.x, _minWorldBounds.x + xGap, _maxWorldBounds.x - xGap);
        nextPosition.z = Mathf.Clamp(nextPosition.z, _minWorldBounds.z + zGap, _maxWorldBounds.z - zGap);

        transform.position = nextPosition;
    }
}