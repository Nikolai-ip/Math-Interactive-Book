using UnityEngine;

namespace StateMachine
{
    public abstract class StateBase:ScriptableObject
    {
        protected StateMachineBase StateMachineBase;
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void Init(StateMachineBase stateMachineBase);
        public abstract void Enter();
        public abstract void Exit();
    }
}