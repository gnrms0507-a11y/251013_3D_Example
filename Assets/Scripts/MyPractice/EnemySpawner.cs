using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    GameObject _enemy;
    [SerializeField] private Transform _spawnPosition; // ���� ������ ������ ��������
    [SerializeField] private float _spawnDelay; // ���� �����Ǵ� �ð�����
    
    private Transform _randomTransform; //���Ͱ� ������ ������ġ
    private Transform _playerTransform; //�i�ư� �÷��̾��� Ʈ������

    //[SerializeField] private int _maxCreateCount; //���ͻ���������

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
        //������ ���� ����ó��
        if (_spawnPosition == null)
            yield break;

            //��� ��ȯ�ϱ� ���� �ݺ���
            while (true)    //createCount <= _maxCreateCount
        {
                if (GameManager.Instance.IsPlaying == true)
                {
                    //���� �ε��� ����
                    int randomIndex = Random.Range(0, _spawnPosition.childCount);

                    //������ �ڽ��� Ʈ������ ������
                    _randomTransform = _spawnPosition.GetChild(randomIndex).transform;

                    //���ο� ��ü ����
                    GameObject newMoverObj = Instantiate(_enemy, _randomTransform);
                    //GameObject newMoverObj = ObjectManager.Instance.CreateOrActiveObject(_enemy, true);

                    //������ ī��Ʈ ����
                    //createCount++;

                }

            yield return _delay;
        }
        

    }

   
   


}
