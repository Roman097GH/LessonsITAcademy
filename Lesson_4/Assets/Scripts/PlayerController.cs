using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, HideInInspector] private Rigidbody _playerRb;
    [SerializeField] private float _movementSpeed = 20.0f;
    [SerializeField] private float _rotationSpeed = 20.0f;

    private Vector3 _movement;
    private Vector3 _rotation;

    private Vector3 _worldMovement;
    private Vector3 _worldRotation;

    private const string  _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _mouseX = "Mouse X";

    [SerializeField] private Animator _playerAnimator;

    private void OnValidate()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ReadInput();

        _playerAnimator.SetFloat("Speed", Vector3.ClampMagnitude(_worldMovement, 1).magnitude);
    }

    private void ReadInput()
    {
        float horizontalInput = Input.GetAxis(_horizontal);
        float verticalInput = Input.GetAxis(_vertical);
        float rotationInput = Input.GetAxis(_mouseX);

        _movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        _movement.y = _playerRb.velocity.y;
        _worldMovement = transform.TransformVector(_movement);

        _rotation = new Vector3(0.0f, rotationInput, 0.0f);
        _worldRotation = transform.TransformVector(_rotation);
    }

    private void FixedUpdate()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        _playerRb.velocity = Vector3.ClampMagnitude(_worldMovement, 1) * _movementSpeed;
        _playerRb.angularVelocity =(_worldRotation * _rotationSpeed);
    }
}
