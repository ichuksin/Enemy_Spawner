using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Pool _pool;
    [SerializeField] private Transform _spawnPointsConteiner;
    private List<Vector3> _spawnPoints = new List<Vector3>();
    private Vector2[] _directions =  {Vector2.left, Vector2.right, Vector2.up, Vector2.down};

    private void Start()
    {
        Transform spawnPointTransform;

        for (int i = 0; i < _spawnPointsConteiner.childCount; i++)
        {
            spawnPointTransform = _spawnPointsConteiner.GetChild(i);
            _spawnPoints.Add(spawnPointTransform.position);
        }

        StartCoroutine(SpawnTimer(_delay));
    }

    private void Spawn( )
    {
        Enemy enemy = _pool.GetObject();
        enemy.Init(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)], _directions[UnityEngine.Random.Range(0, _directions.Length)]);
        enemy.EnemyDied += Release;
    }
    
    private void Release(Enemy enemy)
    {
        enemy.EnemyDied -= Release;
        _pool.Release(enemy);
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
