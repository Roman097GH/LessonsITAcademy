using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Car : MonoBehaviour
{
    [SerializeField] private GameObject _wall;
    [SerializeField] private WheelJoint2D _bWhell;
    [SerializeField] private WheelJoint2D _fWhell;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        
        _wall.gameObject.SetActive(false);
        _bWhell.useMotor = true;
        _fWhell.useMotor = true;
    }
}
