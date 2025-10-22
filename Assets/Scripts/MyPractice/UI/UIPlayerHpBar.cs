using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHpBar : MonoBehaviour , IPlayerOberver
{
    [SerializeField] private float _gap = 1.0f; //Ÿ�ٱ��� �󸶳��������ִ���
    [SerializeField] private Image _imageHpBar; //����� ������ �̹���
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
            _camera = Camera.main;  //ī�޶� ������ ����ī�޶���

            _gapPos = Vector3.forward * _gap;
        }

    }
    //�÷��̾� hp�� ���� - �̹���ä���
    public void OnPlayerHpChanged(float curHp, float maxHp)
    {
        _imageHpBar.fillAmount = curHp / maxHp; //0~1���̷� ������
    }

    //Ÿ���� ���󰡴� ī�޶�
    private void MovetoTarget()
    {
        Vector3 movePos = _player.transform.position + _gapPos;
        transform.position = _camera.WorldToScreenPoint(movePos);   //��ȣ�� ������ǥ�� ��ũ����ġ�� ��������
    }
}

