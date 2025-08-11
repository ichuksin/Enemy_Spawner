using System;
using UnityEngine;

public class Perimeter : MonoBehaviour
{
    public event Action<Enemy> EnemyWentBeyondPerimeter;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            EnemyWentBeyondPerimeter?.Invoke(enemy);
        }
    }
}
