using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake �߻�");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start �߻�");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable �߻�");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update �߻�");
    }
    private void OnDisable()
    {
        Debug.Log("OnDoisable �߻�");
    }
    private void OnDestroy()
    {
        Debug.Log("OnDestroy �߻�");
    }
}
