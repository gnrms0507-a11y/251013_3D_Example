using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BExample : MonoBehaviour , IObserver
{
    [SerializeField] private Subject _subject;

    private void Awake()
    {
        _subject?.AddObserver(this);
    }
    //���� ���������
    private void OnDestroy()
    {
        _subject?.RemoveObserver(this);
    }

    //�������̽� ����Լ�
    public void OnNotify()
    {
        Debug.Log($"{gameObject.name} Received");
    }
}
