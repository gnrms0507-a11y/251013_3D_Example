using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObject : MonoBehaviour
{
    //Cap을 참조할 변수와
    public GameObject Target;

    //Cap의 Transform 컴포넌트를 참조할 변수를 선언
    public Transform TargetTransform;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        ChildrenAction();
    }

    //초기화 함수를 선언
    private void Init()
    {
        //자식 오브젝트에 접근하여 컴포넌트를 참조
        TargetTransform = Target.GetComponent<Transform>();

        //대상을 자신의 하위객체로 편성(상속)
        TargetTransform.SetParent(transform);

        //또는 아래의 코드로도 위 동작과 동일한 결과가 나옴
        //TargetTransform.parent = transform;

    }
    private void ChildrenAction()
    {
        //하위 게임 오브젝트들에 포함된 모든 ChildState 컴포넌트 를 불러와 배열로 반환
        ChildState[] ch = GetComponentsInChildren<ChildState>();


        //배열을 순회
        for(int i =0; i<ch.Length; i++)
        {
            //각 원소의 ChildState의 Parent를 자신으로 설정
            ch[i].parent = gameObject;

            //이름 설정 및 부모의 오브젝트 이름을 출력하는 함수를 호출
            ch[i].SetName($"Child Object - {i}");
            ch[i].PrintParentName();
        }
    }

    /*
         // 해당 GameObject에 연결된 타입 T의 컴포넌트를 반환 
    // 컴포넌트가 여러 개 있다면, 첫 번째 발견된 컴포넌트를 반환
    // 해당 타입의 컴포넌트가 없으면 null을 반환
    GameObject.GetComponent<T>();

    // 해당 GameObject에 연결된 모든 타입 T의 컴포넌트들을 배열로 반환
    // 해당 타입의 컴포넌트가 없으면 빈 배열을 반환
    GameObject.GetComponents<T>();    

    // 해당 GameObject와 그 자식들을 순회하며 타입 T의 첫 번째 컴포넌트를 반환
    // 컴포넌트가 없으면 null을 반환
    GameObject.GetComponentInChildren<T>();

    // 해당 GameObject와 그 자식들을 순회하며 타입 T의 모든 컴포넌트들을 배열로 반환
    // 해당 타입의 컴포넌트가 없으면 빈 배열을 반환
    GameObject.GetComponentsInChildren<T>();

    // 해당 GameObject와 그 부모들을 순회하며 타입 T의 첫 번째 컴포넌트를 반환
    // 만약 그러한 컴포넌트가 없으면 null을 반환
    GameObject.GetComponentInParent<T>();    

    // 해당 GameObject와 그 부모들을 순회하며 타입 T의 모든 컴포넌트들을 배열로 반환
    // 해당 타입의 컴포넌트가 없으면 빈 배열을 반환
    GameObject.GetComponentsInParent<T>();
     */
}
