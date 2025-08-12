using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Pool _pool;
    [SerializeField] private Transform _spawnPointsConteiner;
    private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
    private Vector2[] _directions =  {Vector2.left, Vector2.right, Vector2.up, Vector2.down};

    private void Start()
    {
        Transform spawnPointTransform;

        for (int i = 0; i < _spawnPointsConteiner.childCount; i++)
        {
            spawnPointTransform = _spawnPointsConteiner.GetChild(i);
            _spawnPoints.Add(spawnPointTransform.GetComponent<SpawnPoint>());
        }

        StartCoroutine(SpawnTimer(_delay));
    }

    private void Spawn( )
    {
        int spawnPointIndex = UnityEngine.Random.Range(0, _spawnPoints.Count);
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
