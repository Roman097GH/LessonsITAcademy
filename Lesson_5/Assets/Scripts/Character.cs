using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [HideInInspector, SerializeField] private CharacterController _character;

    [SerializeField] private float _moveSpeed = 10.0f;
    [SerializeField] private float _jumpForce = 10.0f;

    [SerializeField] private float _sensitivityHor = 9.0f;

    private Vector3 _velocity = Vector3.zero;

    private float _gravityModifier = 10.0f;

    private void OnValidate()
    {
        _character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseX = Input.GetAxis("Mouse X");
        var jump = Input.GetAxis("Jump");

        Rotate(mouseX);
        Move(horizontal, vertical, jump);
    }


    private void Rotate(float mouseX)
    {
        transform.Rotate(Vector3.up, mouseX * _sensitivityHor);
    }

    private void Move(float horizontal, float vertical, float jump)
    {
        var direction = new Vector3(horizontal, 0.0f, vertical);
        var moveVector = transform.TransformDirection(direction) * _moveSpeed;

        if (_character.isGrounded)
        {
            if (_velocity.y < 0)
            {
                _velocity.y = 0;
            }

            if (jump != 0)
            {
                _velocity.y += _jumpForce;
            }         
        }

        _velocity.y += -_gravityModifier * Time.deltaTime;

        _character.Move((moveVector + _velocity) * Time.deltaTime);   
    }
}
