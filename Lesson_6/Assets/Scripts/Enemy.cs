using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private Rigidbody _fireBallPrefab;
    [SerializeField] private float _bulletSpeed = 20.0f;

    [SerializeField] private Animator _enemyAnimator;
    private static readonly int Dying = Animator.StringToHash("Dying");

    [SerializeField] private Detect _detect;

    private float _timer;
    private float _shotPeriod = 4.2f;

    private void Update()
    {
        Vector3 relativePos = _target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);

        if (_detect._isGameActive)
        {
            _timer += Time.unscaledDeltaTime;

            if (_timer > _shotPeriod)
            {
                _timer = 0;
                EnemyAttack();
            }
        }
        else
        {
            _spawnPos.gameObject.SetActive(false);
        }
    }

    private void EnemyAttack()
    {
        Rigidbody newfireBall = Instantiate(_fireBallPrefab, _spawnPos.position, Quaternion.identity);
        newfireBall.AddForce(_spawnPos.forward * _bulletSpeed, ForceMode.VelocityChange);
        Destroy(newfireBall.gameObject, 5.0f);
    }

    public void EnemyDeath()
    {
        _enemyAnimator.SetTrigger(Dying);
    }
}
