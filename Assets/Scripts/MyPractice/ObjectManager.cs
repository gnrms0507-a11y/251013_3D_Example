using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class ObjectManager : Singleton<ObjectManager>
{
    /*
    ���� �Ұ�
    �̹� ���������� �Ѿ�, ��, ��Ÿ ���� ������Ʈ�� ������ �ı��� �����ϴ� �Ŵ����� �����մϴ�.
    ������Ʈ Ǯ���� �Ŵ��� �߽��� ���� ������ ���� ���� ������ ����ȭ�ϰ�,
    ����/���� ������ �߾ӿ��� �����ϴ� ���� ��ǥ�Դϴ�.

    ���� ��ǥ
    �Ѿ�, �� ���� ������Ʈ�� �Ŵ��� Ŭ�������� �߾� ����
    ������Ʈ ������ �ı� ������ ȿ�������� ����
    �Ŵ����� ���� ���� �� ��� ����/���� �̺�Ʈ�� �Ͽ�ȭ
    ���� ����

    1. ������Ʈ �Ŵ��� ����
    �̱��� ���� �Ǵ� ���� �� ������ �Ŵ��� ������Ʈ�� ����
    �Ѿ�, ��, ��Ÿ ������Ʈ�� ���� �� �����ϵ��� ����

    2. ����/�ı� ����
    ������Ʈ ���� �� �Ŵ����� ���� �ν��Ͻ�ȭ
    ������Ʈ �ı� �� �Ŵ����� ���� ���� �Ǵ� ��Ȱ��ȭ

    ���� �� ���� ���
    �̱��� �������� �Ŵ��� ���� ��� ����
    UnityEvent �Ǵ� C# �̺�Ʈ�� Ȱ���� ����/����

    ������ �ı� �� ���� �������� ����

     */

    [field: SerializeField] public UnityEvent eventAction { get; private set; } = new UnityEvent();


    [SerializeField] private GameObject _bullet;
    public GameObject Bullet => _bullet;

    [SerializeField] private GameObject _enemy;
    public GameObject Enemy => _enemy;

    //������Ʈ ����
    /// <summary>
    /// isCreate =true -> Instantiate / false -> SetActive(true);
    /// </summary>
    /// <param name="_gameObject"></param>
    /// <param name="isCreate"></param>
    /// <returns></returns>
    public GameObject CreateOrActiveObject(GameObject _gameObject,bool isCreate)
    {
        GameObject obj;
        if (isCreate)
        {
            obj = Instantiate(_gameObject, _gameObject.transform.position, _gameObject.transform.rotation);
            return obj;
        }
        else
        {
            _gameObject.SetActive(true);
            return null;
        }
    }
    //������Ʈ ����
    /// <summary>
    /// isDestory =true -> Destroy / false -> SetActive(false);
    /// </summary>
    /// <param name="_gameObject"></param>
    /// <param name="isDestory"></param>
    public void DestroyOrDisableObject(GameObject _gameObject , bool isDestory)
    {
        if (isDestory)
        {
            Destroy(_gameObject);
        }
        else
        {
            _gameObject.SetActive(false);
        }
    }


    public void DelEnemyObj()
    {
        //���� �����ִ� �� ����
        GameObject[] delEnemyObj = GameObject.FindGameObjectsWithTag(_enemy.tag);
        if (delEnemyObj != null)
        {
            foreach (var obj in delEnemyObj) { Destroy(obj); }
        }
    }

    private void Start()
    {
        eventAction?.Invoke();
    }

}
