using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{   
    //private 변수도 인스펙터에 노출시킬수 있는 SerializeFiled 
    //외부 데이터 변화를 방지하면서도 인스펙터 데이터를 변경하기 위해 자주쓰임
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
