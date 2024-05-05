using System;
using MiniGames;
using MiniGames.ServiceLocatorModule;
using UnityEngine;

namespace SpaceBattle
{
    public class SpaceBattleInputController:InputControllerBase
    {
        [SerializeField] private  InertialMovementController inertialMovementController;
        [SerializeField] private InertialRotationController inertialRotationController;
        [SerializeField] private DoubleShotController doubleShotController;
       
        private bool _isPause = false;
        protected override void OnEnable()
        {
            base.OnEnable();
            controls.SpaceBattle.Shot.started += _ => { doubleShotController.StartShot(); };
            controls.SpaceBattle.Shot.canceled += _ =>  { doubleShotController.StopShot(); };
            controls.SpaceBattle.AddForce.started += _ => { inertialMovementController.EnableEngine();};
            controls.SpaceBattle.AddForce.canceled += _ => {  inertialMovementController.DisableEngine();};
        }

        public void IsPauseEnable()
        {
            _isPause = true;
        }

        public void IsPauseDisable()
        {
            _isPause = false;
        }
        private void Update()
        {
            if (Input.anyKey && _isPause)
            {
                ServiceLocator.Get<IPauseService>().StartGame();
            }
        }

        private void FixedUpdate()
        {
            float moveInputX = controls.SpaceBattle.Rotate.ReadValue<Vector2>().x;
            inertialRotationController.RotateByFloat(moveInputX);
        }
    }
    
}