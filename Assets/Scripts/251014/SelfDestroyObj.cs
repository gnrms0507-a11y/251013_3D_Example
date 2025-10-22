using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyObj : MonoBehaviour
{
    [SerializeField] private float _destoryDelay;
    private float _aliveTime = 0f;
   

    // Update is called once per frame
    void Update()
    {

        _aliveTime += Time.deltaTime;
        

    }
}
