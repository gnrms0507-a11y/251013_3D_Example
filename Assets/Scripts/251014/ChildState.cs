using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildState : MonoBehaviour
{
    //ChildState가 가져야할 필드는 부모 GameObject 변수
    public GameObject parent;

    //자신의 이름을 변경하는 메서드

    public void SetName(string text)
    {
        gameObject.name = text;
    }

    //부모의 이름을 출력하는 메서드

    public void PrintParentName()
    {
        Debug.Log($"{gameObject} 의 부모 오브젝트는 {parent.name} 입니다");
    }

}
