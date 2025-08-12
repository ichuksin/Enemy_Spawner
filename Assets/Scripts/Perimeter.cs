using System;
using UnityEngine;

public class Perimeter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.TryGetComponent<Enemy>(out Enemy enemy))
            enemy.Die();
    }
}
