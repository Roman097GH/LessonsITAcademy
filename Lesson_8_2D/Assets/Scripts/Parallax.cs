using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _distance = -10.0f;
    [SerializeField] private float _startPoint = 10.0f;
    

    private void Update()
    {
        var position = transform.position;
        position.x -= _speed * Time.deltaTime;
        transform.position = position;

        if (position.x <= _distance)
        {
            position.x = _startPoint;
            transform.position = position;
        }
    }
}


