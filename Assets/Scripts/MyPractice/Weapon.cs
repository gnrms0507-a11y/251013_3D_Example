using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Weapon : MonoBehaviour
{
    /*
     �Ѿ� �߻� ��ũ��Ʈ �ۼ�
    WeaponŬ������ �߰��ϰ� �Ѿ��� �߻��ϴ� �Լ��� �ۼ��մϴ�.
    Weapon ������Ʈ�� ������ ������Ʈ�� Player������Ʈ ��ġ�մϴ�.
    Player������Ʈ�� Weapon�� ����ϰ� �Ѿ��� �߻��� �� �ֵ��� �����մϴ�.
    �����̽���(Space) Ű�� ������ Bullet Prefab�� �����ǵ��� �մϴ�.
    ������ �Ѿ��� Weapon��ġ���� ����ϵ��� �մϴ�.
     */

    GameObject _bullet;
    [SerializeField] private int _bulletPoolSize;

    private GameObject[] _bulletPool;
    private int bulletCount ;


    //�ڵ��߻� ���� - 251022 �ۼ�
    [SerializeField] private float _autoShotDelay;
    [SerializeField] private float _autoShotDistance;
    private float _autoShotcoolTime;

    //�ڵ��߻� ���� - 251022 �ۼ�
    private void autoShot()
    {
        if(_autoShotcoolTime > 0)
        {
            _autoShotcoolTime -= Time.deltaTime;
            return;
        }

        Ray ray = new Ray(transform.position, transform.forward);
        bool isHit = Physics.Raycast(ray, out RaycastHit hitInfo, _autoShotDistance);

        if (isHit)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                ShootBullet();
                _autoShotcoolTime = _autoShotDelay;
            }
        }
        
    }

    //�ڵ��߻� ���� - 251022 �ۼ�
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 startPoint = transform.position;
        Vector3 endPoint = transform.position + transform.forward * _autoShotDistance;

        Gizmos.DrawLine(startPoint, endPoint);
    }


    private void Start()
    {
        Init();
        //ObjectManager.Instance.onGameAction.AddListener(Init);
    }

    private void ReLoad()
    {
        bulletCount = _bulletPoolSize;
        Debug.Log("������..");

    }
    public void Init()
    {
        _bullet = ObjectManager.Instance.Bullet;
        _bulletPool = new GameObject[_bulletPoolSize];
        //�Ѿ� �޾ƿ�
        bulletCount = _bulletPoolSize;

        for (int i=0; i<_bulletPool.Length; i++)
        {
            //_bulletPool[i] = Instantiate(_bullet); //�Ѿ˻���
            _bulletPool[i] = ObjectManager.Instance.CreateOrActiveObject(_bullet,true);
            //_bulletPool[i].SetActive(false); //ó���� ��Ȱ��ȭ
            ObjectManager.Instance.DestroyOrDisableObject( _bulletPool[i],false );
        }

        Debug.Log("���� �Ϸ�");
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //Debug.Log("�Ѿ� �߻�!");
        //    ShootBullet();
        //}
        //if (bulletCount <= 0)
        //{
        //    ReLoad();
        //}

        //�ڵ��߻� ���� - 251022 �ۼ�
        autoShot();

    }

    private void ShootBullet()
    {
        foreach(var bull in _bulletPool)
        {
            //activaeSelf - ���ӿ�����Ʈ�� Ȱ��ȭ�Ǿ��ִ��� ����
            if (!bull.activeSelf)
            {
                //�Ѿ��� ��ġ�� ���� ���ӿ�����Ʈ�� ��ġ�� �ٲٰ� Ȱ��ȭ��Ŵ
                bull.transform.position = transform.position;
                //bull.SetActive(true);
                ObjectManager.Instance.CreateOrActiveObject(bull,false);
                bulletCount--;
                return;
            }

        }
    }

   
}
