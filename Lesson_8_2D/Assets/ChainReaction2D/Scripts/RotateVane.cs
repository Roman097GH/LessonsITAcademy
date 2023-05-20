using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateVane : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(-Vector3.forward * (10f * Time.deltaTime));
    }
}
