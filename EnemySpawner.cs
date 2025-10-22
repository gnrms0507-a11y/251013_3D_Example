using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _targetPlayer;  //Ÿ�� �÷��̾�
    [SerializeField] private Transform _spawnPosition; // ���� ������ ������ ��������
    [SerializeField] private float _spawnDelay; // ���� �����Ǵ� �ð�����
    
    private WaitForSeconds _delay;

    private Transform _randomTransform; //���Ͱ� ������ ������ġ
    private Transform _playerTransform; //�i�ư� �÷��̾��� Ʈ������

    [SerializeField] private int _maxCreateCount; //���ͻ���������

    private int createCount = 0;


    private void Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);

        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        //������ ���� ����ó��
        if (_spawnPosition == null)
            yield break;

        //��� ��ȯ�ϱ� ���� �ݺ���
        while (createCount<=_maxCreateCount)
        {
            //���� �ε��� ����
            int randomIndex = Random.Range(0, _spawnPosition.childCount);
            
            //������ �ڽ��� Ʈ������ ������
            _randomTransform = _spawnPosition.GetChild(randomIndex).transform;

            //���ο� ��ü ����
            GameObject newMoverObj = Instantiate(_enemy, _randomTransform);
            createCount++;
   
           
            yield return _delay;
        }

    }

   
   


}
