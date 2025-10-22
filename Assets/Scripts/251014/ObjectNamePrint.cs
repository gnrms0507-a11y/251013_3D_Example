using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNamePrint : MonoBehaviour
{
    //자신이 아닌 다른 오브젝트의 이름을 알기위해선 그 대상 오브젝트의 정보를 알고있어야 한다.
    //대상 오브젝트를 참조하는 변수 - UnityEngine 네임스페이스의 GameObject 클래스이다.
    public GameObject Target;
  

    private void Start()
    {
        //자신 GameObject에 대한 정보를 얻기 위해선 맨앞을 소문자로한 gameObject를 호출하면됨
        //Target 오브젝트의 이름도 반환받아보자
        Debug.Log($"{gameObject.name} : {Target.name} !");
    }


}
