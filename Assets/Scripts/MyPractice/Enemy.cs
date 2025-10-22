using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHp;

    private Transform targetPlayer;

    private int _currnetHp; //피통
    [SerializeField]private float moveSpeed = 2.0f;


    private void Start()
    {
        Init();
    }
   
    private void Init()
    {
        _currnetHp = _maxHp; //피통 초기화

        //플레이어 오브젝트를 찾아서 쫒아가게함
        targetPlayer = GameObject.FindWithTag("Player").transform;

        //플레이어 없으면 로그출력
        if (targetPlayer == null)
        {
            Debug.Log("캐릭터가 없음");
            return;
        }

        else
        {
            gameObject.transform.LookAt(targetPlayer.transform.position);
        }
        Debug.Log("적 이닛 ");
    }

    //플레이어 총알에 맞았을때
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("PlayerBullet"))
        {
            TakeDamage();
        }

        if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player == null)
                return;

            player.Demage();

            //gameObject.SetActive(false); // 플레이어와 부딪히면 사라짐
            ObjectManager.Instance.DestroyOrDisableObject(gameObject, false);
        }
    }
    private void TakeDamage()
    {
        _currnetHp--;
        Debug.Log("몬스터 체력1감소");
        if (_currnetHp <= 0)
        {
            ObjectManager.Instance.DestroyOrDisableObject(gameObject, true);
           //Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        MoveObj();
    }
    private void MoveObj()
    {
        gameObject.transform.position = 
            Vector3.MoveTowards(
                gameObject.transform.position,
            targetPlayer.transform.position, 
            moveSpeed * Time.deltaTime);
    }
}
