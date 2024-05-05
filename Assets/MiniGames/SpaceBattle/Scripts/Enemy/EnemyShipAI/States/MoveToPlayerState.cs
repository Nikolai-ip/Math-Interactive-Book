using System;
using MiniGames;
using StateMachine;
using UnityEngine;

namespace SpaceBattle.Enemy.States
{
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyStates/MoveToPlayerState",fileName = "MoveToPlayerState")]
    public class MoveToPlayerState:StateBase
    {
        private InertialMovementController _movementController;
        private Transform _target;
        [SerializeField] private float _duration;
        private float _attackRange;
        private float _elapsedTime;
        private Transform _thisTr;
        public event Action<bool> EngineWorked;
        public override void Update()
        {

        }

        public override void FixedUpdate()
        {
            CheckRotateStateTransition();
        }

        private void CheckRotateStateTransition()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _duration || InAttackRange())
            {
                stateMachine.ChangeState<RotateToPlayerState>();
            }
        }

        private bool InAttackRange()
        {
            return Vector2.Distance(_thisTr.position, _target.position) <= _attackRange;
        }
        public override void Init(StateMachineBase stateMachineBase)
        {
            stateMachine = stateMachineBase;
            _movementController = stateMachine.GetComponent<InertialMovementController>();
            _target = FindObjectOfType<Player>().GetComponent<Transform>();
            _thisTr = stateMachine.GetComponent<Transform>();
            _attackRange = stateMachine.GetStateGlobal<ShotState>().AttackRange;
        }

        public override void Enter()
        {
            _elapsedTime = 0;
            _movementController.EnableEngine();
            EngineWorked?.Invoke(true);
        }

        public override void Exit()
        {
            _movementController.DisableEngine();
            EngineWorked?.Invoke(false);
        }
    }
}