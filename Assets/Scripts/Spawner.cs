using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Pool _pool;
    [SerializeField] private SpawnPoint[] _spawnPoints ;

    private void Start()
    {
        StartCoroutine(SpawnTimer(_delay));
    }

    private void Spawn( )
    {
        int spawnPointIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
        Enemy enemy = _pool.GetObject(_spawnPoints[spawnPointIndex].EnemyPrefab);
        enemy.Init(_spawnPoints[spawnPointIndex].transform.position, _spawnPoints[spawnPointIndex].Target);
    }
    
    private IEnumerator SpawnTimer(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            Spawn();
            yield  return wait;
        }
    }
}
