using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public abstract class StateMachineBase:MonoBehaviour
    {
        [SerializeField] protected List<StateBase> states;
        protected StateBase currentState;

        protected void Start()
        {
            foreach (var state in states)
            {
                state.Init(this);
            }
            currentState = states[0];
            currentState.Enter();
        }

        public void ChangeState(StateBase newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }
        protected void Update()
        {
            currentState.Update();
        }

        protected void FixedUpdate()
        {
            currentState.Update();
        }
    }
}