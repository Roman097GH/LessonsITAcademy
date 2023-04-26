using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [HideInInspector, SerializeField] private CharacterController _character;

    [SerializeField] private float _moveSpeed = 10.0f;
    [SerializeField] private float _rotationSpeed = 10.0f;

    private Vector3 _velocity = Vector3.zero;

    private readonly float _gravityModifier = 10.0f;

    [SerializeField] private Camera _camera;
    [SerializeField] private Animator _animator;
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void OnValidate()
    {
        _character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseX = Input.GetAxis("Mouse X");

        Move(horizontal, vertical);
    }

    private void Move(float horizontal, float vertical)
    {
        var direction = new Vector3(horizontal, 0.0f, vertical).normalized;
        var cameraDirection = _camera.transform.TransformDirection(direction);
        cameraDirection.y = 0;
        cameraDirection.Normalize();
        var moveVector = cameraDirection * _moveSpeed;

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(cameraDirection), Time.deltaTime * _rotationSpeed);
        }

        _animator.SetBool(IsWalking, horizontal != 0 || vertical != 0);
        
        _velocity.y += -_gravityModifier * Time.deltaTime;

        _character.Move((moveVector + _velocity) * Time.deltaTime);   
    }
}
