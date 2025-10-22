using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objPrefab;
    [SerializeField] private int _spawnCount;
    [SerializeField] private int _spawnDistance;


    private void Update()
    {
        
    }

    private void SpawnObj()
    {
        for(int i=0; i < _spawnCount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(_spawnDistance, _spawnDistance), 0f, Random.Range(_spawnDistance, _spawnDistance));
        }
    }
   
}
