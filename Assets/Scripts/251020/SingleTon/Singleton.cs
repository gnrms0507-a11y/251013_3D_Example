using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour    //�����غ� ��ӹ��� �ֵ鸸 ��밡��
{
    private static T _instance;

    //�ܺ� ȣ��� ������Ƽ , ã�� Ÿ���� �̱����� ������ ã�ƺ��� �׷��� ������ ���� ������(���ӿ�����Ʈ) ����
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

    //�ߺ�üũ �� �����ɱ���
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
