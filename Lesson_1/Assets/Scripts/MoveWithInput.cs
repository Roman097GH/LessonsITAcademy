using UnityEngine;

public class MoveWithInput : MonoBehaviour
{
    [SerializeField] private Transform _positionC;
    [SerializeField] private Transform _positionD;

    [SerializeField] private float _speed = 15.0f;

    private const string _horizontalInput = "Horizontal";

    private void Start()
    {
        transform.position = _positionC.position;
        _positionC.parent = null;
        _positionD.parent = null;
    }

    private void Update()
    {
        LimitPosition();
        Move();
    }

    private void Move()
    {
        float _hInput = Input.GetAxis(_horizontalInput);
        Vector3 _xMovement = new(_hInput * _speed * Time.deltaTime, 0.0f, 0.0f);
        transform.Translate(_xMovement);
    }

    private void LimitPosition()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, _positionC.position.x, _positionD.position.x);
        transform.position = position;
    }
}
