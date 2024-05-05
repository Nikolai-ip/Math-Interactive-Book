using System;
using SpaceBattle.Enemy;
using SpaceBattle.Enemy.States;
using StateMachine;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private StateMachineBase _stateMachine;
    private Enemy _enemy;
    public void Init()
    {
        _animator = GetComponent<Animator>();
        _stateMachine = GetComponent<StateMachineBase>();
        _enemy = GetComponent<Enemy>();
        var moveToPlayerState = _stateMachine.GetState<MoveToPlayerState>();
        moveToPlayerState.EngineWorked += OnEngineWorked;
        _enemy.Died += PlayDestroyAnimation;
    }

    private void OnDestroy()
    {
        _stateMachine.GetState<MoveToPlayerState>().EngineWorked -= OnEngineWorked;
        _enemy.Died -= PlayDestroyAnimation;
    }

    public void OnEngineWorked(bool value)
    {
        _animator.SetBool("EngineEnable", value);
    }

    public void PlayDestroyAnimation()
    {
        _animator.SetTrigger("Destroy");
    }
}
