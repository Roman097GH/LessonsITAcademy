using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _metallBallRb;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _metallBallRb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
