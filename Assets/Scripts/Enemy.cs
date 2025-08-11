using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    public void Init(Vector3 position, Vector2 direction)
    {
        transform.position = position;
        _mover.Init(direction);
        Enable();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }
}
