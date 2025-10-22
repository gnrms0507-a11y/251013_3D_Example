using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AExample : MonoBehaviour , IObserver
{
    [SerializeField] private Subject _subject;

    private void Awake()
    {
        _subject?.AddObserver(this);
    }
    //주의 까먹지말기
    private void OnDestroy()
    {
        _subject?.RemoveObserver(this);
    }

    //인터페이스 약속함수
    public void OnNotify()
    {
        Debug.Log($"{gameObject.name} Received");
    }
}
