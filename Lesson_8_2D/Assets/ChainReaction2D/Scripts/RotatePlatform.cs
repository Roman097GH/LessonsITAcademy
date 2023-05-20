using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private Animator _oneSideAnimator;
    [SerializeField] private Rigidbody2D _metallBallRb;
    private static readonly int IsOneSidePlatTrig = Animator.StringToHash("IsOneSidePlatTrig");

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _oneSideAnimator.SetTrigger(IsOneSidePlatTrig);
            _metallBallRb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
