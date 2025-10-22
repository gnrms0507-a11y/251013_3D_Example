using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    /*
     유니티 이벤트 함수 작성해보기 251013

    과제 내용
    이벤트 함수 구현
    다음과 같은 Unity 라이프 사이클 관련 함수들을 MonoBehaviour 상속 클래스에 작성하세요.
    Awake()
    OnEnable()
    Start()
    Update()
    FixedUpdate()
    LateUpdate()
    OnDisable()
    OnDestroy()
    각 함수에서 Debug.Log($"{함수명} 호출")을 출력하도록 작성합니다.
    실행 및 로그 확인
    Unity에서 Play 버튼을 눌러 실행 후, Console 창에서 함수 호출 순서를 확인하세요.
    스크린샷 촬영
    각 이벤트 함수가 호출된 Console 창의 출력 로그를 캡처합니다.


    Debug.Log($"{MethodBase.GetCurrentMethod().Name}처음 시작시 Awake 발생");
     */

    // 시작

    //오브젝트 생성시 단 1회만 호출 !
    private void Awake()
    {
        Debug.Log("Awake호출");
    }
    
    //오브젝트의 활성화 마다 발생하는 OnEnable!
    private void OnEnable()
    {
        Debug.Log("활성화는 OnEnable");
    }

    //Awake 이후 오브젝트의 생성  및 활성화시 단1회만 호출되는 Start

    void Start()
    {
        Debug.Log("Start 호출");
    }

    // 매 프레임마다 1회 호출되며 오브젝트와 스크립트의 생존 및 활성화시에만 동작함
    void Update()
    {
        Debug.Log("Update");
        
    }

    ////연산 수행시 Update() 이후에 수행하지만 실행과 정지를 사용자가 자유롭게 사용할 수 있는 서브루틴입니다.
    //private void Coroutine()
    //{
    //    Debug.Log("나 사라졌어");
    //}


    /*
     매 함수 호출 간격이 다른 Update와 달리 FixedUpdate는 함수 호출 간격이 일정하도록 보장된다. 
    따라서 매번 일정한 주기로 똑같은 연산을 처리해야 하는 물리 계산 및 업데이트, 또는 Ray 처리에 주로 사용되는 함수이다.
    Rigidbody 컴포넌트를 활용하는 코드의 실행은 FixedUpdate에서 이루어지는 것이 더 정확한 물리 계산이 가능하다.
    FixedUpdate 함수 자체도 Unity script lifecycle flowchart의 Physics 영역에 속한 것을 확인할 수 있다.

    물리 계산에 유리하다는 특성은 FixedUpdate의 호출 간격이 일정하다는 것 덕분인데, 
    이는 Update가 매 프레임 실행되던 것에 비해 FixedUpdate는 프레임 속도에 관계없이 
    Fixed Timestep이라는 정해진 시간 간격에 따라 호출되기 때문이다. 
    상단 Edit 탭을 클릭하여 Project Settings의 Time에서 
    현재 프로젝트의 Fixed Timestep이 몇 초로 설정되어 있는지 확인할 수 있다.
    */
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 호출");
        
    }

    /*
    Update가 완전히 끝난 후 프레임당 한 번 호출되는 함수로, 
    Update가 마무리된 후에 호출되기 때문에 3인칭 카메라에 주로 사용된다. 
    플레이어의 움직임을 Update에서 완료하고 이동한 위치에 따라 
    카메라의 위치를 LateUpdate에서 이동하는 식으로 구현할 때 사용된다.
     */
    private void LateUpdate()
    {
        Debug.Log("LateUpdate 호출");
       

    }
    //오브젝트의 '비활성화'시마다 1회 호출되며, Update() 이후에 호출됩니다
    private void OnDisable()
    {
        Debug.Log("OnDisable 호출");
    }

    //오브젝트의 '파괴' 시 1회 호출됩니다.
    private void OnDestroy()
    {
        Debug.Log("OnDestroy호출 ");
    }



}
