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

    //�÷��̾� ����Ƽ �̺�Ʈ�� �������� �ڷ�ƾ �����Լ� , �ڷ�ƾ�� �ΰ��̾�� ����(�ߺ��������)
    public void MoveToPlayer()
    {
        if(moveCorutine == null)
        {
            moveCorutine = StartCoroutine(MoveToTarget(player.transform)); 
        }
    }

    //�÷��̾ ���� �̵��ϴµ� ������ ���ݱ��� �̵��ϸ� ���ߵ����ϴ� �ڷ�ƾ�Լ�
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

            //������ ������ ������
            yield return null;
        }
    }









}
