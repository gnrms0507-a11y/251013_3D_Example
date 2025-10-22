using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildState : MonoBehaviour
{
    //ChildState�� �������� �ʵ�� �θ� GameObject ����
    public GameObject parent;

    //�ڽ��� �̸��� �����ϴ� �޼���

    public void SetName(string text)
    {
        gameObject.name = text;
    }

    //�θ��� �̸��� ����ϴ� �޼���

    public void PrintParentName()
    {
        Debug.Log($"{gameObject} �� �θ� ������Ʈ�� {parent.name} �Դϴ�");
    }

}
