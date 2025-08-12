using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Ship _target;

    public Enemy EnemyPrefab => _enemyPrefab;
    public Ship Target => _target;
}
