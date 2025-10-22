using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        RotateObj();
    }

    private void RotateObj()
    {
        //Vector3.up¿∫ 0,1,0

        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }


}
