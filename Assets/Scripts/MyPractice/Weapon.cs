using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Weapon : MonoBehaviour
{
    /*
     총알 발사 스크립트 작성
    Weapon클래스를 추가하고 총알을 발사하는 함수를 작성합니다.
    Weapon 컴포넌트를 가지는 오브젝트를 Player오브젝트 배치합니다.
    Player컴포넌트에 Weapon을 등록하고 총알을 발사할 수 있도록 연결합니다.
    스페이스바(Space) 키를 누르면 Bullet Prefab이 생성되도록 합니다.
    생성한 총알은 Weapon위치에서 출발하도록 합니다.
     */

    GameObject _bullet;
    [SerializeField] private int _bulletPoolSize;

    private GameObject[] _bulletPool;
    private int bulletCount ;


    //자동발사 구현 - 251022 작성
    [SerializeField] private float _autoShotDelay;
    [SerializeField] private float _autoShotDistance;
    private float _autoShotcoolTime;

    //자동발사 구현 - 251022 작성
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

    //자동발사 구현 - 251022 작성
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
        Debug.Log("재장전..");

    }
    public void Init()
    {
        _bullet = ObjectManager.Instance.Bullet;
        _bulletPool = new GameObject[_bulletPoolSize];
        //총알 받아옴
        bulletCount = _bulletPoolSize;

        for (int i=0; i<_bulletPool.Length; i++)
        {
            //_bulletPool[i] = Instantiate(_bullet); //총알생성
            _bulletPool[i] = ObjectManager.Instance.CreateOrActiveObject(_bullet,true);
            //_bulletPool[i].SetActive(false); //처음엔 비활성화
            ObjectManager.Instance.DestroyOrDisableObject( _bulletPool[i],false );
        }

        Debug.Log("장전 완료");
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //Debug.Log("총알 발사!");
        //    ShootBullet();
        //}
        //if (bulletCount <= 0)
        //{
        //    ReLoad();
        //}

        //자동발사 구현 - 251022 작성
        autoShot();

    }

    private void ShootBullet()
    {
        foreach(var bull in _bulletPool)
        {
            //activaeSelf - 게임오브젝트가 활성화되어있는지 여부
            if (!bull.activeSelf)
            {
                //총알의 위치를 현재 게임오브젝트의 위치로 바꾸고 활성화시킴
                bull.transform.position = transform.position;
                //bull.SetActive(true);
                ObjectManager.Instance.CreateOrActiveObject(bull,false);
                bulletCount--;
                return;
            }

        }
    }

   
}
