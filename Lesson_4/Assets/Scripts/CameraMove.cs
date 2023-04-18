using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _minimumVert = -45.0f;
    [SerializeField] private float _maximumVert = 45.0f;
    [SerializeField] private float _sensitivityVert = 9.0f;
    private float _rotationX = 0;

    private void LateUpdate()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);
        transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
    }
}
