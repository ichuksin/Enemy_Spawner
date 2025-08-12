using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    public event Action<Enemy> EnemyDied;

    public void Init(Vector3 position, Vector2 direction)
    {
        transform.position = position;
        _mover.Init(direction);
        Enable();
    }

    public void Die()
    {
        EnemyDied?.Invoke(this);
        gameObject.SetActive(false);
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }
}
