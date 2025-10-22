using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTest : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        transform.LookAt(_target.position);
    }
}
