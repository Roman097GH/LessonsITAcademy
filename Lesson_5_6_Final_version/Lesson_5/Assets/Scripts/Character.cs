using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [HideInInspector, SerializeField] private CharacterController _character;

    private float _currentSpeed;
    [SerializeField] private float _moveSpeed = 10.0f;
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private float _jumpSpeed = 5.0f;

    private Vector3 _velocity = Vector3.zero;

    private readonly float _gravityModifier = 10.0f;

    [SerializeField] private Camera _camera;
    [SerializeField] private Animator _characterAnimator;
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
    private static readonly int Attack = Animator.StringToHash("AttackTrigger");
    private static readonly int Death = Animator.StringToHash("DeathTrigger");
    private static readonly int Jump = Animator.StringToHash("JumpTrigger");

    private void OnValidate()
    {
        _character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var jump = Input.GetAxis("Jump");

        if (Input.GetButtonDown("Fire1"))
        {
            CharacterAttack();
        }

        Move(horizontal, vertical, jump);
    }

    private void Move(float horizontal, float vertical, float jump)
    {
        var runMultiplicator= Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
        var direction = new Vector3(horizontal, 0.0f, vertical).normalized;
        var speed = _moveSpeed * runMultiplicator;
        _currentSpeed = Mathf.MoveTowards(_currentSpeed, speed, Time.deltaTime);
        var cameraDirection = _camera.transform.TransformDirection(direction);
        cameraDirection.y = 0;
        cameraDirection.Normalize();
        var moveVector = cameraDirection * _currentSpeed;

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(cameraDirection), Time.deltaTime * _rotationSpeed);
        }

        _characterAnimator.SetBool(IsWalking, horizontal != 0 || vertical != 0);
        _characterAnimator.SetFloat(MoveSpeed, _currentSpeed / (_moveSpeed * 2));

        if (_character.isGrounded)
        {
            if (_velocity.y < 0)
            {
                _velocity.y = 0;                
            }

            if (jump != 0)
            {
                _velocity.y += _jumpSpeed;
                _characterAnimator.SetTrigger(Jump);
            }
        }

        _velocity.y += -_gravityModifier * Time.deltaTime;

        _character.Move((moveVector + _velocity) * Time.deltaTime);   
    }
    
    public void CharacterDeath()
    {
        _characterAnimator.SetTrigger(Death);
        _character.GetComponent<Character>().enabled = false;
    }
    
    private void CharacterAttack()
    {
        _characterAnimator.SetTrigger(Attack);
    }
}
