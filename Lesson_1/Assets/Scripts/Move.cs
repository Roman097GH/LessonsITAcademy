using UnityEngine;

public enum Direction
{
    Left, Right
}

public class Move : MonoBehaviour
{
    [SerializeField] private Transform _positionA;
    [SerializeField] private Transform _positionB;
    [SerializeField] private float _speed = 3.0f;

    [SerializeField] private Direction _currentDirection;

    private void Start()
    {
        _positionA.parent = null;
        _positionB.parent = null;
    }

    private void Update()
    {
        MoweTowardsPosition();
        //MoveTransformPosition();
    }

    private void MoweTowardsPosition()
    {
        float step = _speed * Time.deltaTime;

        if (_currentDirection == Direction.Right)
        {
            transform.position = Vector3.MoveTowards(transform.position, _positionB.position, step);

            if (transform.position.x >= _positionB.position.x)
            {
                _currentDirection = Direction.Left;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _positionA.position, step);

            if (transform.position.x <= _positionA.position.x)
            {
                _currentDirection = Direction.Right;
            }
        }
    }

    private void MoveTransformPosition()
    {
        if (_currentDirection == Direction.Right)
        {
            transform.position += new Vector3(Time.deltaTime * _speed, 0.0f, 0.0f);

            if (transform.position.x > _positionB.position.x)
            {
                _currentDirection = Direction.Left;
            }
        }
        else
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0.0f, 0.0f);

            if (transform.position.x < _positionA.position.x)
            {
                _currentDirection = Direction.Right;
            }
        }
    }
}
