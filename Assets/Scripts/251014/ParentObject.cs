using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObject : MonoBehaviour
{
    //Cap�� ������ ������
    public GameObject Target;

    //Cap�� Transform ������Ʈ�� ������ ������ ����
    public Transform TargetTransform;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        ChildrenAction();
    }

    //�ʱ�ȭ �Լ��� ����
    private void Init()
    {
        //�ڽ� ������Ʈ�� �����Ͽ� ������Ʈ�� ����
        TargetTransform = Target.GetComponent<Transform>();

        //����� �ڽ��� ������ü�� ��(���)
        TargetTransform.SetParent(transform);

        //�Ǵ� �Ʒ��� �ڵ�ε� �� ���۰� ������ ����� ����
        //TargetTransform.parent = transform;

    }
    private void ChildrenAction()
    {
        //���� ���� ������Ʈ�鿡 ���Ե� ��� ChildState ������Ʈ �� �ҷ��� �迭�� ��ȯ
        ChildState[] ch = GetComponentsInChildren<ChildState>();


        //�迭�� ��ȸ
        for(int i =0; i<ch.Length; i++)
        {
            //�� ������ ChildState�� Parent�� �ڽ����� ����
            ch[i].parent = gameObject;

            //�̸� ���� �� �θ��� ������Ʈ �̸��� ����ϴ� �Լ��� ȣ��
            ch[i].SetName($"Child Object - {i}");
            ch[i].PrintParentName();
        }
    }

    /*
         // �ش� GameObject�� ����� Ÿ�� T�� ������Ʈ�� ��ȯ 
    // ������Ʈ�� ���� �� �ִٸ�, ù ��° �߰ߵ� ������Ʈ�� ��ȯ
    // �ش� Ÿ���� ������Ʈ�� ������ null�� ��ȯ
    GameObject.GetComponent<T>();

    // �ش� GameObject�� ����� ��� Ÿ�� T�� ������Ʈ���� �迭�� ��ȯ
    // �ش� Ÿ���� ������Ʈ�� ������ �� �迭�� ��ȯ
    GameObject.GetComponents<T>();    

    // �ش� GameObject�� �� �ڽĵ��� ��ȸ�ϸ� Ÿ�� T�� ù ��° ������Ʈ�� ��ȯ
    // ������Ʈ�� ������ null�� ��ȯ
    GameObject.GetComponentInChildren<T>();

    // �ش� GameObject�� �� �ڽĵ��� ��ȸ�ϸ� Ÿ�� T�� ��� ������Ʈ���� �迭�� ��ȯ
    // �ش� Ÿ���� ������Ʈ�� ������ �� �迭�� ��ȯ
    GameObject.GetComponentsInChildren<T>();

    // �ش� GameObject�� �� �θ���� ��ȸ�ϸ� Ÿ�� T�� ù ��° ������Ʈ�� ��ȯ
    // ���� �׷��� ������Ʈ�� ������ null�� ��ȯ
    GameObject.GetComponentInParent<T>();    

    // �ش� GameObject�� �� �θ���� ��ȸ�ϸ� Ÿ�� T�� ��� ������Ʈ���� �迭�� ��ȯ
    // �ش� Ÿ���� ������Ʈ�� ������ �� �迭�� ��ȯ
    GameObject.GetComponentsInParent<T>();
     */
}
