using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _button;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _button.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                _gameManager.AddClick(2);
            }
        }
    }
}
