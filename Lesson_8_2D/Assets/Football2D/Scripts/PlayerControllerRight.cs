using UnityEngine;

namespace Football2D
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerControllerRight : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed = 5.0f;
        [SerializeField] private Animator _animator;
        private static readonly int HitTrigger = Animator.StringToHash("HitTrigger");

        private void OnValidate()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                _animator.SetTrigger(HitTrigger);
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                _rigidbody2D.AddForce(new Vector2(0.0f, 50.0f), ForceMode2D.Impulse);
            }

            var hInput = Input.GetAxis("Horizontal");
            _rigidbody2D.AddForce(new Vector2(hInput * _speed, 0.0f), ForceMode2D.Impulse);
        }
    }
}
