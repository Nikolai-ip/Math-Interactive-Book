using MiniGames;
using StateMachine;
using UnityEngine;

namespace SpaceBattle.Enemy.States
{
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyStates/RotateToPlayerState",fileName = "RotateToPlayerState")]
    public class RotateToPlayerState:StateBase
    {
        private Transform _target;
        [SerializeField] private float _duration;
        private float _elapsedTime;
        private float _attackRange;
        private Transform _tr;
        public override void Update()
        {
        }

        public override void FixedUpdate()
        {
            RotateToTarget();
            TimerToEndRotateState();
        }

        public void RotateToTarget()
        {
            Vector2 direction = (_target.position - _tr.position).normalized;
            float angleToTarget = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float angleDifference = Mathf.DeltaAngle(_tr.eulerAngles.z, angleToTarget);

            if (Mathf.Abs(angleDifference) > 0.1f)
            {
                float z = Mathf.LerpAngle(_tr.eulerAngles.z, _tr.eulerAngles.z + angleDifference - 90, _elapsedTime / _duration);
                _tr.eulerAngles = new Vector3(0, 0,  z );
            }
        }

        private void TimerToEndRotateState()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _duration)
            {
                if (InAttackRange())
                {
                    stateMachine.ChangeState<ShotState>();
                }
                else
                {
                    stateMachine.ChangeState<MoveToPlayerState>();
                }
            }
        }
        private bool InAttackRange()
        {
            return Vector2.Distance(_tr.position, _target.position) <= _attackRange;
        }
        public override void Init(StateMachineBase stateMachineBase)
        {
            stateMachine = stateMachineBase;
            _target = FindObjectOfType<Player>().GetComponent<Transform>();
            _tr = stateMachine.GetComponent<Transform>();
            _attackRange = stateMachine.GetStateGlobal<ShotState>().AttackRange;
        }

        public override void Enter()
        {
            _elapsedTime = 0;
        }

        public override void Exit()
        {
        }
    }
}