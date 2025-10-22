using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake 惯积");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start 惯积");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable 惯积");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update 惯积");
    }
    private void OnDisable()
    {
        Debug.Log("OnDoisable 惯积");
    }
    private void OnDestroy()
    {
        Debug.Log("OnDestroy 惯积");
    }
}
