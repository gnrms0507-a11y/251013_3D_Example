using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //몬스터 프리팹

    [SerializeField] private GameObject _monsterPrefab;


    //몬스터 생성시 생성 위치의 범위
    //여기서 [SerializedField] , [Range] 는 프로그램에 우선적으로 정보를 대괄호에 넣어 제공하는것 , Attribute (애트리뷰트)라고 부른다
    //이를통해 유니티의 인스펙터에 노출시키고 범위가 지정된 슬라이드게이지로 표현할것을 미리 알려주는것
    [SerializeField][Range(0, 5)] private float _positionScope;

    //생성된 몬스터 보관할 Queue
    private Queue<GameObject> _monsters = new Queue<GameObject>();

    private int _spawnCount = 0;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //S키누르면 생성
            Spawn();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //D키누르면 파괴
            Despawn();
        }
    }


    private void Spawn()
    {
        //프리팹 기준으로 게임오브젝트 생성
        //Instantiate 함수는 Object Class 에 정의된 함수로 이번에는 position 과 rotation을 지정할수 있는 메서드를 사용할것임 (오버로딩되어있어 다양한 옵션을제공)

        //두번째 인자로 랜덤포지션을 반환하고 , 세번째인자로 자신 오브젝트의 로테이션을 주입함
        //포지션은 범위내 랜덤으로 생성되고 회전각은 모두 일정하게 생성될것임.
        GameObject monster = Instantiate(_monsterPrefab,RandPos(),transform.rotation);

        //큐에 몬스터 추가하고 몬스터이름 변경
        _monsters.Enqueue(monster);
        monster.name = $"Monster - {_spawnCount}";
        ++_spawnCount;

    }


    private void Despawn()
    {
        //Queue에 몬스터가 없는상황에는 삭제하지않음
        if (_monsters.Count > 0)
        {
            //Queue에서 몬스터 하나꺼내서 파괴
            Destroy(_monsters.Dequeue());
        }
    }

    //랜덤 포지션을 반환받는 함수
    private Vector3 RandPos()
    {
        //Vector3와 X,Z 축만 지정된 범위내에서 랜덤으로 반환하는 함수제작
        //Random.Range 순서대로 x축 , 0f - y축 , z축이다
        Vector3 pos = new Vector3(Random.Range(-_positionScope, _positionScope), 0f, Random.Range(-_positionScope, _positionScope));

        return pos;
    }

}
