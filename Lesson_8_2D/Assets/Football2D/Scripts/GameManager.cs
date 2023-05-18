using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreLeftText;
    [SerializeField] private TextMeshProUGUI _scoreRightText;
    [SerializeField] private Transform _playerTransformRight;
    [SerializeField] private Transform _playerTransformLeft;
    [SerializeField] private Transform _ballTransform;
    [SerializeField] private Rigidbody2D _ballRb;
    [SerializeField] private Rigidbody2D _playerRbRight;
    [SerializeField] private Rigidbody2D _playerRbLeft;
    
    [SerializeField] private GameObject _endPanel;

    private Vector3 _startPosPlayerRight;
    private Vector3 _startPosPlayerLeft;
    private Vector3 _startPosBall;
    
    public int CountLeft;
    public int CountRight;
    
    private void Start()
    {
        Time.timeScale = 1;
        _scoreLeftText.text = "0";
        _scoreRightText.text = "0";
        _startPosPlayerRight = _playerTransformRight.position;
        _startPosPlayerLeft = _playerTransformLeft.position;
        _startPosBall = _ballTransform.position;
    }

    public void UpdateScore(bool isLeftGoal)
    {
        if (isLeftGoal)
        {
            CountLeft += 1;
            _scoreRightText.text = CountLeft.ToString();
            
            if (CountLeft == 3)
            {
                GameWin();
            }
        }
        else
        {
            CountRight += 1;
            _scoreLeftText.text = CountRight.ToString();
            
            if (CountRight == 3)
            {
                GameWin();
            }
        }
    }

    public void TransformReset()
    {
        _playerTransformRight.position = _startPosPlayerRight;
        _playerTransformLeft.position = _startPosPlayerLeft;
        
        _ballTransform.position = _startPosBall;
        _ballRb.velocity = new Vector2(0, 0);
        _ballRb.angularVelocity = 0;
        
        _playerRbRight.velocity = new Vector2(0, 0);
        _playerRbRight.angularVelocity = 0;
        
        _playerRbLeft.velocity = new Vector2(0, 0);
        _playerRbLeft.angularVelocity = 0;
    }

    public void GameWin()
    {
        Time.timeScale = 0;
        _endPanel.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
