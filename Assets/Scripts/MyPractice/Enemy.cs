using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHp;

    private Transform targetPlayer;

    private int _currnetHp; //����
    [SerializeField]private float moveSpeed = 2.0f;


    private void Start()
    {
        Init();
    }
   
    private void Init()
    {
        _currnetHp = _maxHp; //���� �ʱ�ȭ

        //�÷��̾� ������Ʈ�� ã�Ƽ� �i�ư�����
        targetPlayer = GameObject.FindWithTag("Player").transform;

        //�÷��̾� ������ �α����
        if (targetPlayer == null)
        {
            Debug.Log("ĳ���Ͱ� ����");
            return;
        }

        else
        {
            gameObject.transform.LookAt(targetPlayer.transform.position);
        }
        Debug.Log("�� �̴� ");
    }

    //�÷��̾� �Ѿ˿� �¾�����
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

            //gameObject.SetActive(false); // �÷��̾�� �ε����� �����
            ObjectManager.Instance.DestroyOrDisableObject(gameObject, false);
        }
    }
    private void TakeDamage()
    {
        _currnetHp--;
        Debug.Log("���� ü��1����");
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
