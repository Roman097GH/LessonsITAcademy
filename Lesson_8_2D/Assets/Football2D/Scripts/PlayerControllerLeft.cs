using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerControllerLeft : MonoBehaviour
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
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                _animator.SetTrigger(HitTrigger);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _rigidbody2D.AddForce(new Vector2(0.0f, 50.0f), ForceMode2D.Impulse);
            }

            var hInput = Input.GetAxis("Horizontal_2");
            _rigidbody2D.AddForce(new Vector2(hInput * _speed, 0.0f), ForceMode2D.Impulse);
        }
    }
