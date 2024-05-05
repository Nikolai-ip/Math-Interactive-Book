using System;
using UnityEngine;

namespace SpaceBattle
{
    public class PlayerShipAnimator:MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnEngineWorked(bool value)
        {
            _animator.SetBool("EngineEnable", value);
        }

        public void PlayDieAnimation()
        {
            _animator.SetTrigger("Die");
        }

        public void PlayWinAnimation()
        {
            _animator.SetTrigger("Win");
        }
    }
}