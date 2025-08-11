using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private Perimeter[] _perimeters;

    private void OnEnable()
    {
        foreach (Perimeter perimeter in _perimeters)
        {
            perimeter.EnemyWentBeyondPerimeter += EnemyDestroy;
        }  
    }

    private void OnDisable()
    {
        foreach (Perimeter perimeter in _perimeters)
        {
            perimeter.EnemyWentBeyondPerimeter -= EnemyDestroy;
        }
    }

    private void EnemyDestroy (Enemy enemy)
    {
        _pool.Release(enemy);
        enemy.Die();
    }
}
