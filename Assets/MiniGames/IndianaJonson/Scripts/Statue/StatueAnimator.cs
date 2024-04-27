using System;
using UnityEngine;

public class StatueAnimator : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayShotAnimation()
    {
        _animator.SetTrigger("Shot");
    }
}
