using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Transform _enemyConteiner;
    [SerializeField] private Queue<Enemy> _enemys = new Queue<Enemy>();

    public Enemy GetObject(Enemy prefab)
    {
        Enemy enemy;
        
        if (_enemys.Count == 0)
            enemy = Instantiate(prefab, _enemyConteiner);
        else
            enemy = _enemys.Dequeue();

        return enemy;
    }

    public void Release(Enemy enemy)
    {
        _enemys.Enqueue(enemy);
    }
}
