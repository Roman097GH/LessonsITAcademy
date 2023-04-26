using UnityEngine;
using UnityEngine.Serialization;

public class Detect : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Enemy _enemy;

    [FormerlySerializedAs("IsGameActive")] public bool _isGameActive;

    private void Start()
    {
        _isGameActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("FireBall")) return;
        Destroy(other.gameObject);
        _character.CharacterDeath();
        _enemy.EnemyDeath();
        _isGameActive = false;
    }
}
