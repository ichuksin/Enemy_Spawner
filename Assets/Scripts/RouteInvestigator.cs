using UnityEngine;

public class RouteInvestigator : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private int _currentWaypoint;
    [SerializeField] private Vector3 _currentDirection;

    private Vector3 _previousDirection;

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
            _previousDirection = _currentDirection;
            _currentDirection = (_waypoints[_currentWaypoint].position - transform.position);
            transform.rotation *=  Quaternion.FromToRotation(_previousDirection, _currentDirection);
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed*Time.deltaTime);
    }
}
