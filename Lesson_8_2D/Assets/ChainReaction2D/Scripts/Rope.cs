using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _metallBall;
    
    private void Update()
    {
        _lineRenderer.SetPosition(1, _metallBall.position);
    }
}
