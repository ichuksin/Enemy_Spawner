using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _direction = Vector2.left;

    public void Init(Vector2 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
