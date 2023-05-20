using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakJointByTap : MonoBehaviour
{
    [SerializeField] private Joint2D _joint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _joint.breakForce = 0;
            Destroy(this);
        }
    }
}
