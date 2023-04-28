using UnityEngine;

public class Detect : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private GameManager _gameManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("FireBall") || _gameManager.IsPause) return;
        
        Destroy(other.gameObject);
        _character.CharacterDeath();
        _enemyAnimator.enabled = false;
        _gameManager.ShowMenuRestartAndExit();
        _gameManager.IsGameActive = false;
    }
}
