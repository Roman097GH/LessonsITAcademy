using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private GameObject _oneSidePlatform;
    [SerializeField] private Animator _oneSideAnimator;
    private static readonly int IsOneSidePlatTrig = Animator.StringToHash("IsOneSidePlatTrig");

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log(other.gameObject.name);
            _oneSideAnimator.SetTrigger(IsOneSidePlatTrig);
        }
    }
}
