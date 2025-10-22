using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    /*
     총알의 이동 스크립트 작성
    Bullet클래스를 추가하고 총알이 정면 방향으로 이동하는 함수를 작성합니다.
    작성한 Bullet클래스를 총알 프리팹에 적용하고 이동속도 등을 설정합니다.
    */

    /*
    Bullet 오브젝트 세팅
    Bullet Prefab에 Collider를 추가합니다.
    충돌 감지를 위해 Is Trigger 여부를 상황에 맞게 설정합니다.
    Bullet.cs를 수정해 충돌 관련 기능을 추가합니다.
    총알이 충돌할 충돌체도 따로 설정해주세요

    Enemy 오브젝트 세팅
    Enemy Prefab을 생성하고 Collider와 Rigidbody를 추가합니다.
    Enemy.cs 스크립트를 생성하고 충돌 처리를 위한 함수를 추가합니다.
    적은 총알과 반대로 플레이어 정면 방향으로부터 플레이어 방향으로 이동합니다.
    충돌 감지를 위해 Is Trigger 여부를 상황에 맞게 설정합니다.
    적이 충돌할 충돌체도 따로 설정해주세요

    충돌 스크립트 작성
    Bullet.cs과 Enmey.cs를 수정해 지정된 대상과 충돌 시 제거되도록 합니다.
    OnTriggerEnter등의 충돌 처리 함수를 사용합니다.
     */

    [SerializeField] private float _shotForce;

    //private Vector3 startPosition;
    //private Rigidbody _rigidbody;


    //적을 맞췄을때 로그출력
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy 타격!");

            ////총알사라짐
            gameObject.SetActive(false);

            ////총알 파괴
            //Destroy(gameObject);
        }
        if(other.tag =="Area")
        {
            Debug.Log("벽넘어감");

            //총알 파괴
            gameObject.SetActive(false);
        }
    }


    private void Update()
    {
        ActivateAction();
    }

  

    private void ActivateAction()
    {
       //_rigidbody.AddForce(transform.forward * _shotForce, ForceMode.Impulse);
        transform.Translate(transform.forward * _shotForce * Time.deltaTime);
    }
}
