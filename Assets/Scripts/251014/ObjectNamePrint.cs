using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNamePrint : MonoBehaviour
{
    //�ڽ��� �ƴ� �ٸ� ������Ʈ�� �̸��� �˱����ؼ� �� ��� ������Ʈ�� ������ �˰��־�� �Ѵ�.
    //��� ������Ʈ�� �����ϴ� ���� - UnityEngine ���ӽ����̽��� GameObject Ŭ�����̴�.
    public GameObject Target;
  

    private void Start()
    {
        //�ڽ� GameObject�� ���� ������ ��� ���ؼ� �Ǿ��� �ҹ��ڷ��� gameObject�� ȣ���ϸ��
        //Target ������Ʈ�� �̸��� ��ȯ�޾ƺ���
        Debug.Log($"{gameObject.name} : {Target.name} !");
    }


}
