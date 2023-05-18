using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPlatform : MonoBehaviour
{
    [SerializeField] private Animator _openPlatformAnimator;
    private static readonly int IsOpenPlatformTrigger = Animator.StringToHash("IsOpenPlatformTrigger");

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _openPlatformAnimator.SetTrigger(IsOpenPlatformTrigger);
        }
    }
}
