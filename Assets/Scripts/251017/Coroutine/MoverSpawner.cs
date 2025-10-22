using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSpawner : MonoBehaviour
{
    //소환할 대상 프리팹
    [SerializeField] private GameObject _moverPrefab;
    //소환 대상에게 전달할 웨이포인트 정보
    [SerializeField] private Transform _waypointBox;
    //소환 간격
    [SerializeField] private float _spawnDelay;

    private WaitForSeconds _delay;

    //private Coroutine _spawnEnemyCorutine;

    //private void StartSpawnEnemy()
    //{
    //    if( _spawnEnemyCorutine != null)
    //    {

    //    }
    //}

    private void Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnMover());
    }

    //소환에 사용할 코루틴 함수
    private IEnumerator SpawnMover()
    {
        //안전을 위한 예외처리
        if (_waypointBox == null)
            yield break;

        //계속 소환하기 위한 반복문
        while (true)
        {
            //새로운 객체 생성
            GameObject newMoverObj = Instantiate(_moverPrefab, transform);
            //생성한 객체에서 우리가 만든 웨이포인트 이동 컴포넌트의 정보를 가져옴
            WaypointMover newMover = newMoverObj.GetComponent<WaypointMover>();
            //이동할 위치들에 대한 정보를 전달해줌
            newMover?.SetWayPointBox(_waypointBox);

            //정해진 시간 간격으로 동작하도록 설정
            yield return _delay;
        }
    }
}