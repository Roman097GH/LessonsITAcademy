using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private int _count = 0;

    public void AddScore()
    {
        _count += 1;

        if (_count == 5)
        {
            _gameManager.GameWin();
        }
    }
}
