using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public abstract class StateMachineBase:MonoBehaviour
    {
        [SerializeField] protected List<StateBase> stateScriptObjects;
        [SerializeField] protected List<StateBase> states;
        [SerializeField] protected StateBase currentState;
        [SerializeField] protected bool debug;
        public virtual void Init()
        {
            foreach (var state in stateScriptObjects)
            {
                var cloneState = Instantiate(state);
                cloneState.Init(this);
                states.Add(cloneState);
            }

            currentState = states[0];
            currentState.Enter();
        }

        public void ChangeState<T>() where T:StateBase
        {
            var newState = GetState<T>();
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
            if (debug)
                Debug.Log(currentState.name);
        }

        public T GetState<T>() where T : StateBase
        {
            return (T)states.Find(state => state is T);
        }

        public T GetStateGlobal<T>() where T : StateBase
        {
            return (T)stateScriptObjects.Find(state => state is T);
        }
        protected void Update()
        {
            currentState.Update();
        }

        protected void FixedUpdate()
        {
            currentState.FixedUpdate();
        }
        
    }
}