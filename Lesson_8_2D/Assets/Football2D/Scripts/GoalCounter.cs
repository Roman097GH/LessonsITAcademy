using System;
using UnityEngine;

namespace Football2D
{
    public class GoalCounter : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private bool _isLeftGoal;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                Debug.Log("Goal!");
                _gameManager.UpdateScore(_isLeftGoal);
                _gameManager.TransformReset();
            }
        }
    }
}
