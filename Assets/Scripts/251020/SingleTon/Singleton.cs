using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour    //모노비해비어를 상속받은 애들만 사용가능
{
    private static T _instance;

    //외부 호출용 프로퍼티 , 찾는 타입의 싱글톤이 없으면 찾아보고 그래도 없으면 새로 생성후(게임오브젝트) 설정
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject singletonObj = new GameObject();

                    _instance = singletonObj.AddComponent<T>();

                    singletonObj.name = typeof(T).ToString();
                }
            }
            return _instance;
        }
    }

    //중복체크 및 연결기능구현
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

    }

}
