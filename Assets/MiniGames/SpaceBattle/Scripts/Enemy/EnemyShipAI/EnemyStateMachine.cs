using System;
using SpaceBattle.Enemy.States;
using StateMachine;
using UnityEngine;

namespace SpaceBattle.Enemy
{
    public class EnemyStateMachine:StateMachineBase
    {
        private void OnDrawGizmos()
        {
            if (!debug) return;
            var attackState = GetStateGlobal<ShotState>();
            if (attackState)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, attackState.AttackRange);
            }
        }
        
    }
}
