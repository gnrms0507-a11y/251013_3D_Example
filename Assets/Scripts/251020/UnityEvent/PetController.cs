using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveStopDistance;

    private Coroutine moveCorutine;

    private void Awake()
    {
        Init();
    }

    private void OnDestroy()
    {
        player.OnPetCalled.RemoveListener(MoveToPlayer);
    }

    private void Init()
    {
        player.OnPetCalled.AddListener(MoveToPlayer);
    }

    //플레이어 유니티 이벤트에 연결해줄 코루틴 실행함수 , 코루틴이 널값이어야 실행(중복실행방지)
    public void MoveToPlayer()
    {
        if(moveCorutine == null)
        {
            moveCorutine = StartCoroutine(MoveToTarget(player.transform)); 
        }
    }

    //플레이어를 따라서 이동하는데 정해진 간격까지 이동하면 멈추도록하는 코루틴함수
    private IEnumerator MoveToTarget(Transform target)
    {
        while (true)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);

            if(distance<= moveStopDistance)
            {
                moveCorutine = null;
                yield break;
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
                );

            //프레임 단위로 실행함
            yield return null;
        }
    }









}
