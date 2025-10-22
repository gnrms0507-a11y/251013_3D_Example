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
            //오브젝트에 박스를 쳤을때 그 박스의 하프사이즈만큼
            _playerExtents = playerColider.bounds.extents;
        }

        if (_movingPlane != null)
        {
            //Bound - 범위 MeshRenderer의 범위를 가져온다
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
        //게임중 아니면 리턴
        if(GameManager.Instance.IsPlaying==false)
        {
            return;
        }

        //인풋컴포넌트의 x축값 , y좌표 , z축값
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