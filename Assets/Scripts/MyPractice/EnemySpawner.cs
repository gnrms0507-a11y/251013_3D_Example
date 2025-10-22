using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    GameObject _enemy;
    [SerializeField] private Transform _spawnPosition; // 적이 생성될 포지션 가져오기
    [SerializeField] private float _spawnDelay; // 적이 생성되는 시간간격
    
    private Transform _randomTransform; //몬스터가 생성될 랜덤위치
    private Transform _playerTransform; //쫒아갈 플레이어의 트랜스폼

    //[SerializeField] private int _maxCreateCount; //몬스터생성마릿수

    //private int createCount = 1;

    private Coroutine _coroutine;
    private WaitForSeconds _delay;

    private void Awake()
    {
        ObjectManager.Instance.eventAction.AddListener(EnemySpawn);
    }

    private void OnDestroy()
    {
        ObjectManager.Instance.eventAction.RemoveListener(EnemySpawn);
    }
   
    public void EnemySpawn()
    {
        _delay = new WaitForSeconds(_spawnDelay);
        _enemy = ObjectManager.Instance.Enemy;
        if (_coroutine==null)
        {
            _coroutine = StartCoroutine(CreateEnemy());
        }
    }
    private IEnumerator CreateEnemy()
    {
        //안전을 위한 예외처리
        if (_spawnPosition == null)
            yield break;

            //계속 소환하기 위한 반복문
            while (true)    //createCount <= _maxCreateCount
        {
                if (GameManager.Instance.IsPlaying == true)
                {
                    //랜덤 인덱스 생성
                    int randomIndex = Random.Range(0, _spawnPosition.childCount);

                    //랜덤한 자식의 트랜스폼 가져옴
                    _randomTransform = _spawnPosition.GetChild(randomIndex).transform;

                    //새로운 객체 생성
                    GameObject newMoverObj = Instantiate(_enemy, _randomTransform);
                    //GameObject newMoverObj = ObjectManager.Instance.CreateOrActiveObject(_enemy, true);

                    //몹생성 카운트 증감
                    //createCount++;

                }

            yield return _delay;
        }
        

    }

   
   


}
