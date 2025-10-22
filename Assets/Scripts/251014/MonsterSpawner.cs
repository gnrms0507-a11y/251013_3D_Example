using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //���� ������

    [SerializeField] private GameObject _monsterPrefab;


    //���� ������ ���� ��ġ�� ����
    //���⼭ [SerializedField] , [Range] �� ���α׷��� �켱������ ������ ���ȣ�� �־� �����ϴ°� , Attribute (��Ʈ����Ʈ)��� �θ���
    //�̸����� ����Ƽ�� �ν����Ϳ� �����Ű�� ������ ������ �����̵�������� ǥ���Ұ��� �̸� �˷��ִ°�
    [SerializeField][Range(0, 5)] private float _positionScope;

    //������ ���� ������ Queue
    private Queue<GameObject> _monsters = new Queue<GameObject>();

    private int _spawnCount = 0;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //SŰ������ ����
            Spawn();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //DŰ������ �ı�
            Despawn();
        }
    }


    private void Spawn()
    {
        //������ �������� ���ӿ�����Ʈ ����
        //Instantiate �Լ��� Object Class �� ���ǵ� �Լ��� �̹����� position �� rotation�� �����Ҽ� �ִ� �޼��带 ����Ұ��� (�����ε��Ǿ��־� �پ��� �ɼ�������)

        //�ι�° ���ڷ� ������������ ��ȯ�ϰ� , ����°���ڷ� �ڽ� ������Ʈ�� �����̼��� ������
        //�������� ������ �������� �����ǰ� ȸ������ ��� �����ϰ� �����ɰ���.
        GameObject monster = Instantiate(_monsterPrefab,RandPos(),transform.rotation);

        //ť�� ���� �߰��ϰ� �����̸� ����
        _monsters.Enqueue(monster);
        monster.name = $"Monster - {_spawnCount}";
        ++_spawnCount;

    }


    private void Despawn()
    {
        //Queue�� ���Ͱ� ���»�Ȳ���� ������������
        if (_monsters.Count > 0)
        {
            //Queue���� ���� �ϳ������� �ı�
            Destroy(_monsters.Dequeue());
        }
    }

    //���� �������� ��ȯ�޴� �Լ�
    private Vector3 RandPos()
    {
        //Vector3�� X,Z �ุ ������ ���������� �������� ��ȯ�ϴ� �Լ�����
        //Random.Range ������� x�� , 0f - y�� , z���̴�
        Vector3 pos = new Vector3(Random.Range(-_positionScope, _positionScope), 0f, Random.Range(-_positionScope, _positionScope));

        return pos;
    }

}
