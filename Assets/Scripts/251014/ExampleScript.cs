using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    /*
     ����Ƽ �̺�Ʈ �Լ� �ۼ��غ��� 251013

    ���� ����
    �̺�Ʈ �Լ� ����
    ������ ���� Unity ������ ����Ŭ ���� �Լ����� MonoBehaviour ��� Ŭ������ �ۼ��ϼ���.
    Awake()
    OnEnable()
    Start()
    Update()
    FixedUpdate()
    LateUpdate()
    OnDisable()
    OnDestroy()
    �� �Լ����� Debug.Log($"{�Լ���} ȣ��")�� ����ϵ��� �ۼ��մϴ�.
    ���� �� �α� Ȯ��
    Unity���� Play ��ư�� ���� ���� ��, Console â���� �Լ� ȣ�� ������ Ȯ���ϼ���.
    ��ũ���� �Կ�
    �� �̺�Ʈ �Լ��� ȣ��� Console â�� ��� �α׸� ĸó�մϴ�.


    Debug.Log($"{MethodBase.GetCurrentMethod().Name}ó�� ���۽� Awake �߻�");
     */

    // ����

    //������Ʈ ������ �� 1ȸ�� ȣ�� !
    private void Awake()
    {
        Debug.Log("Awakeȣ��");
    }
    
    //������Ʈ�� Ȱ��ȭ ���� �߻��ϴ� OnEnable!
    private void OnEnable()
    {
        Debug.Log("Ȱ��ȭ�� OnEnable");
    }

    //Awake ���� ������Ʈ�� ����  �� Ȱ��ȭ�� ��1ȸ�� ȣ��Ǵ� Start

    void Start()
    {
        Debug.Log("Start ȣ��");
    }

    // �� �����Ӹ��� 1ȸ ȣ��Ǹ� ������Ʈ�� ��ũ��Ʈ�� ���� �� Ȱ��ȭ�ÿ��� ������
    void Update()
    {
        Debug.Log("Update");
        
    }

    ////���� ����� Update() ���Ŀ� ���������� ����� ������ ����ڰ� �����Ӱ� ����� �� �ִ� �����ƾ�Դϴ�.
    //private void Coroutine()
    //{
    //    Debug.Log("�� �������");
    //}


    /*
     �� �Լ� ȣ�� ������ �ٸ� Update�� �޸� FixedUpdate�� �Լ� ȣ�� ������ �����ϵ��� ����ȴ�. 
    ���� �Ź� ������ �ֱ�� �Ȱ��� ������ ó���ؾ� �ϴ� ���� ��� �� ������Ʈ, �Ǵ� Ray ó���� �ַ� ���Ǵ� �Լ��̴�.
    Rigidbody ������Ʈ�� Ȱ���ϴ� �ڵ��� ������ FixedUpdate���� �̷������ ���� �� ��Ȯ�� ���� ����� �����ϴ�.
    FixedUpdate �Լ� ��ü�� Unity script lifecycle flowchart�� Physics ������ ���� ���� Ȯ���� �� �ִ�.

    ���� ��꿡 �����ϴٴ� Ư���� FixedUpdate�� ȣ�� ������ �����ϴٴ� �� �����ε�, 
    �̴� Update�� �� ������ ����Ǵ� �Ϳ� ���� FixedUpdate�� ������ �ӵ��� ������� 
    Fixed Timestep�̶�� ������ �ð� ���ݿ� ���� ȣ��Ǳ� �����̴�. 
    ��� Edit ���� Ŭ���Ͽ� Project Settings�� Time���� 
    ���� ������Ʈ�� Fixed Timestep�� �� �ʷ� �����Ǿ� �ִ��� Ȯ���� �� �ִ�.
    */
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate ȣ��");
        
    }

    /*
    Update�� ������ ���� �� �����Ӵ� �� �� ȣ��Ǵ� �Լ���, 
    Update�� �������� �Ŀ� ȣ��Ǳ� ������ 3��Ī ī�޶� �ַ� ���ȴ�. 
    �÷��̾��� �������� Update���� �Ϸ��ϰ� �̵��� ��ġ�� ���� 
    ī�޶��� ��ġ�� LateUpdate���� �̵��ϴ� ������ ������ �� ���ȴ�.
     */
    private void LateUpdate()
    {
        Debug.Log("LateUpdate ȣ��");
       

    }
    //������Ʈ�� '��Ȱ��ȭ'�ø��� 1ȸ ȣ��Ǹ�, Update() ���Ŀ� ȣ��˴ϴ�
    private void OnDisable()
    {
        Debug.Log("OnDisable ȣ��");
    }

    //������Ʈ�� '�ı�' �� 1ȸ ȣ��˴ϴ�.
    private void OnDestroy()
    {
        Debug.Log("OnDestroyȣ�� ");
    }



}
