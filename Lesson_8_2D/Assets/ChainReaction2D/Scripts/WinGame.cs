using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            _menuPanel.gameObject.SetActive(true);
        }
    }
}
