using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _sensitivityVert = 9.0f;

    private void Update()
    {
        var mouseY = Input.GetAxis("Mouse Y");

        Rotate(mouseY);
    }

    private void Rotate(float mouseY)
    {    
        transform.Rotate(Vector3.right, -mouseY * _sensitivityVert);
    }
}
