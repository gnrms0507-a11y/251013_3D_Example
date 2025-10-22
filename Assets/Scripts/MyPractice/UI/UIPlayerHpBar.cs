using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHpBar : MonoBehaviour , IPlayerOberver
{
    [SerializeField] private float _gap = 1.0f; //타겟기준 얼마나떨어져있는지
    [SerializeField] private Image _imageHpBar; //기능을 연결할 이미지
    [SerializeField] private Player _player;

    private Camera _camera;
    private Vector3 _gapPos;

    private void Awake()
    {
        _player.AddHPObserver(this);
    }
    private void OnDestroy()
    {
        _player.RemoveHPObserver(this);
    }
   
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        MovetoTarget();
    }
    private void Init()
    {
        if (_camera == null)
        {
            _camera = Camera.main;  //카메라 없으면 메인카메라사용

            _gapPos = Vector3.forward * _gap;
        }

    }
    //플레이어 hp바 변동 - 이미지채우기
    public void OnPlayerHpChanged(float curHp, float maxHp)
    {
        _imageHpBar.fillAmount = curHp / maxHp; //0~1사이로 들어갈것임
    }

    //타겟을 따라가는 카메라
    private void MovetoTarget()
    {
        Vector3 movePos = _player.transform.position + _gapPos;
        transform.position = _camera.WorldToScreenPoint(movePos);   //괄호안 월드좌표를 스크린위치로 변경해줌
    }
}

