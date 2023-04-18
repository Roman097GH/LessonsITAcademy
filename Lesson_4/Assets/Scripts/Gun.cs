using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ChargeIcon _chargeIcon;

    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _spawnPositionBullet;
    [SerializeField] private float _bulletSpeed = 10.0f;
    [SerializeField] private float _shotPeriod = 0.5f;

    [SerializeField] private float _currentMassBullet;
    [SerializeField] private float _minMassBullet = 1.0f;
    [SerializeField] private float _maxMassBullet = 10.0f;

    private float _timer;

    private float _maxCharge;
    private float _currentCharge;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _chargeIcon.StartCharge();
    }

    private void Awake()
    {
        _minMassBullet = _bulletPrefab.mass;
        _maxCharge = _maxMassBullet;
        _currentMassBullet = _minMassBullet;
    }


    private void Update()
    {
        _currentMassBullet = Mathf.Clamp(_currentMassBullet, _minMassBullet, _maxMassBullet);

        _timer += Time.unscaledDeltaTime;

        if (_timer > _shotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                Shot();
            } 
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _currentMassBullet += Time.unscaledDeltaTime;
            _currentCharge = _currentMassBullet;

            _chargeIcon.SetChargeValue(_currentCharge, _maxCharge);

            if (_currentMassBullet >= _maxMassBullet)
            {
                Mathf.Ceil(_currentMassBullet);
                _chargeIcon.StopCharge();
            }
        }

        if(Input.GetKey(KeyCode.E))
        {
            _chargeIcon.StartCharge();

            _currentMassBullet -= Time.unscaledDeltaTime;
            _currentCharge = _currentMassBullet;

            _chargeIcon.SetChargeValue(_currentCharge , _maxCharge);

            if (_currentMassBullet <= _minMassBullet)
            {
                Mathf.Ceil(_currentMassBullet);
            }
        }
    }

    private void Shot()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit raycastHit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out raycastHit))
            targetPoint = raycastHit.point;
        else
            targetPoint = ray.GetPoint(70.0f);

        Vector3 direction = targetPoint - _spawnPositionBullet.position;

        Rigidbody newBullet = Instantiate(_bulletPrefab, _spawnPositionBullet.position, Quaternion.identity);
        newBullet.transform.forward = direction.normalized;
        newBullet.mass = _currentMassBullet;
        newBullet.AddForce(direction.normalized * _bulletSpeed, ForceMode.VelocityChange);
    }
}
