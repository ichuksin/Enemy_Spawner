using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _enemyConteiner;
    [SerializeField] private int _initialCount;
    [SerializeField]  private Queue<Enemy> _enemys = new Queue<Enemy>();

    public Enemy GetObject()
    {
        Enemy enemy;
        
        if (_enemys.Count == 0)
            enemy = Instantiate(_prefab, _enemyConteiner);
        else
            enemy = _enemys.Dequeue();

        return enemy;
    }

    public void Release(Enemy enemy)
    {
        _enemys.Enqueue(enemy);
    }
    
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < _initialCount; i++)
        {
            Enemy enemy = Instantiate(_prefab, _enemyConteiner);
            enemy.Die();
            _enemys.Enqueue(enemy);
        }
    }
}
