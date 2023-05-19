using UnityEngine;

namespace Football2D.Scripts
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _ballRb;
        [SerializeField] private float _hitForce = 5.0f;
        private Vector3 distance;

        private void Update()
        {
            distance = _ballRb.transform.position - transform.position;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _ballRb.AddForce(distance * _hitForce, ForceMode2D.Impulse);
        }
    }
}
