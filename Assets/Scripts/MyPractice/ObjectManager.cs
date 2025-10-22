using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class ObjectManager : Singleton<ObjectManager>
{
    /*
    과제 소개
    이번 과제에서는 총알, 적, 기타 게임 오브젝트의 생성과 파괴를 관리하는 매니저를 설계합니다.
    오브젝트 풀링과 매니저 중심의 관리 구조를 통해 게임 성능을 최적화하고,
    생성/삭제 로직을 중앙에서 제어하는 것이 목표입니다.

    과제 목표
    총알, 적 등의 오브젝트를 매니저 클래스에서 중앙 관리
    오브젝트 생성과 파괴 로직을 효율적으로 구현
    매니저를 통해 게임 내 모든 생성/삭제 이벤트를 일원화
    구현 내용

    1. 오브젝트 매니저 설계
    싱글톤 패턴 또는 게임 내 유일한 매니저 오브젝트로 구현
    총알, 적, 기타 오브젝트를 참조 및 관리하도록 설정

    2. 생성/파괴 관리
    오브젝트 생성 시 매니저를 통해 인스턴스화
    오브젝트 파괴 시 매니저를 통해 제거 또는 비활성화

    구현 시 참고 요소
    싱글톤 패턴으로 매니저 접근 방식 통일
    UnityEvent 또는 C# 이벤트를 활용한 생성/삭제

    생성과 파괴 시 게임 로직과의 연계

     */

    [field: SerializeField] public UnityEvent eventAction { get; private set; } = new UnityEvent();


    [SerializeField] private GameObject _bullet;
    public GameObject Bullet => _bullet;

    [SerializeField] private GameObject _enemy;
    public GameObject Enemy => _enemy;

    //오브젝트 생성
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
    //오브젝트 제거
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
        //씬에 남아있는 적 삭제
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
