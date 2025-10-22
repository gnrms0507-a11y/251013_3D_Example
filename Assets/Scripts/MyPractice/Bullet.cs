using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    /*
     �Ѿ��� �̵� ��ũ��Ʈ �ۼ�
    BulletŬ������ �߰��ϰ� �Ѿ��� ���� �������� �̵��ϴ� �Լ��� �ۼ��մϴ�.
    �ۼ��� BulletŬ������ �Ѿ� �����տ� �����ϰ� �̵��ӵ� ���� �����մϴ�.
    */

    /*
    Bullet ������Ʈ ����
    Bullet Prefab�� Collider�� �߰��մϴ�.
    �浹 ������ ���� Is Trigger ���θ� ��Ȳ�� �°� �����մϴ�.
    Bullet.cs�� ������ �浹 ���� ����� �߰��մϴ�.
    �Ѿ��� �浹�� �浹ü�� ���� �������ּ���

    Enemy ������Ʈ ����
    Enemy Prefab�� �����ϰ� Collider�� Rigidbody�� �߰��մϴ�.
    Enemy.cs ��ũ��Ʈ�� �����ϰ� �浹 ó���� ���� �Լ��� �߰��մϴ�.
    ���� �Ѿ˰� �ݴ�� �÷��̾� ���� �������κ��� �÷��̾� �������� �̵��մϴ�.
    �浹 ������ ���� Is Trigger ���θ� ��Ȳ�� �°� �����մϴ�.
    ���� �浹�� �浹ü�� ���� �������ּ���

    �浹 ��ũ��Ʈ �ۼ�
    Bullet.cs�� Enmey.cs�� ������ ������ ���� �浹 �� ���ŵǵ��� �մϴ�.
    OnTriggerEnter���� �浹 ó�� �Լ��� ����մϴ�.
     */

    [SerializeField] private float _shotForce;

    //private Vector3 startPosition;
    //private Rigidbody _rigidbody;


    //���� �������� �α����
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy Ÿ��!");

            ////�Ѿ˻����
            gameObject.SetActive(false);

            ////�Ѿ� �ı�
            //Destroy(gameObject);
        }
        if(other.tag =="Area")
        {
            Debug.Log("���Ѿ");

            //�Ѿ� �ı�
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
