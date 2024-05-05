using StateMachine;
using UnityEngine;

namespace SpaceBattle.Enemy.States
{
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyStates/ShotState",fileName = "ShotState")]

    public class ShotState:StateBase
    {
        [field:SerializeField] public float AttackRange { get; private set; }
        private DoubleShotController _shotController;
        [SerializeField] private float _duration;
        private float _elapsedTime;
        public override void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _duration)
            {
                stateMachine.ChangeState<MoveToPlayerState>();
            } 
        }

        public override void FixedUpdate()
        {           

        }

        public override void Init(StateMachineBase stateMachineBase)
        {
            stateMachine = stateMachineBase;
            _shotController = stateMachine.GetComponent<DoubleShotController>();
        }

        public override void Enter()
        {
            _elapsedTime = 0;
            _shotController.StartShot();
        }

        public override void Exit()
        {
            _shotController.StopShot();
        }
    }
}