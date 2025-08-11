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
        foreach (var item in _spawnPointsConteiner.GetComponentsInChildren<Transform>())
            if (item.position != _spawnPointsConteiner.transform.position)
                _spawnPoints.Add(item.position);

        StartCoroutine(SpawnTimer(_delay));
    }

    private void Spawn( )
    {
        Enemy enemy = _pool.GetObject();

        enemy.Init(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)], _directions[UnityEngine.Random.Range(0, _directions.Length)]);
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
