using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiSnowMan : MonoBehaviour
{
    [SerializeField] private string _hiText;
    [SerializeField] private GameObject _target;

    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
  
    }
    void Awake()
    {
        Init();
    }

    
    void Init()
    {
        if(_target != null)
        {
            _target.transform.SetParent(transform);
        }
    }
  
    void PrintChildHi()
    {
        //ChildComponent[] childComs = transform.
    }


}
