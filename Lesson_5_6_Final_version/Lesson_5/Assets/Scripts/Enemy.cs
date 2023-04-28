using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private Rigidbody _fireBallPrefab;
    [SerializeField] private float _bulletSpeed = 20.0f;

    [SerializeField] private GameManager _gameManager;

    private float _timer;
    [SerializeField] private float _shotPeriod = 4.2f;

    private void Update()
    {
        var relativePos = _target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);

       if (!_gameManager.IsGameActive) return;
       
        _timer += Time.deltaTime;

        if (!(_timer > _shotPeriod)) return;
        
        _timer = 0;
        EnemyAttack();
    }

    public void EnemyAttack()
    {
        if (_gameManager.IsPause != false) return;
        
        Rigidbody newfireBall = Instantiate(_fireBallPrefab, _spawnPos.position, Quaternion.identity);
        newfireBall.AddForce(_spawnPos.forward * _bulletSpeed, ForceMode.VelocityChange);
        Destroy(newfireBall.gameObject, 5.0f);
    }
}
