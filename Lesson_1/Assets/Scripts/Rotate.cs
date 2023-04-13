using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed = 5.0f;

    private void Update()
    {
        transform.Rotate(_speed * Time.deltaTime * _rotation.normalized);
    }
}
