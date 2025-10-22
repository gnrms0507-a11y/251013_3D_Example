using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{   
    //private ������ �ν����Ϳ� �����ų�� �ִ� SerializeFiled 
    //�ܺ� ������ ��ȭ�� �����ϸ鼭�� �ν����� �����͸� �����ϱ� ���� ���־���
    [SerializeField] private List<GameObject> _prefabs = new List<GameObject>();


    private void Start()
    {
        PrintPrefabsName();
    }
    private void PrintPrefabsName()
    {
        foreach(var pre in _prefabs)
        {
            Debug.Log(pre.name);
        }
    }
}
