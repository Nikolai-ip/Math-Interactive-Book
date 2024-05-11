using System;
using UnityEngine;

public class ReloadButtonAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayHighLightAnim()
    {
        _animator.SetTrigger("Highlighted");
    }
}
