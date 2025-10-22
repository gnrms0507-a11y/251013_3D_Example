using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    //������Ʈ�� ȸ��

    //ȸ���ӵ� ����
    [SerializeField] private float _rotateSpeed;


    private void Update()
    {
        RotateObj();
    }

    private void RotateObj()
    {
        //y���� ȸ����ų���̹Ƿ� y�࿡ �����̴� ���ǵ� + ��ŸŸ���� ����
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x, //x�� �״��
            transform.rotation.eulerAngles.y + _rotateSpeed * Time.deltaTime, //y���� ȸ���ӵ��� ����
            transform.rotation.z //z�� �״��
            );
    }
}
