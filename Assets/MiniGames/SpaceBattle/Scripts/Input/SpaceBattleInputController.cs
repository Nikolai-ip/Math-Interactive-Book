using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceBattle
{
    public class SpaceBattleInputController:InputControllerBase
    {
        [FormerlySerializedAs("_playerMoveController")] [SerializeField] private  InertialMovementController inertialMovementController;
        [FormerlySerializedAs("_playerRotateController")] [SerializeField] private InertialRotationController inertialRotationController;
        [FormerlySerializedAs("_playerShotController")] [SerializeField] private DoubleShotController doubleShotController;
        protected override void OnEnable()
        {
            base.OnEnable();
            controls.SpaceBattle.Shot.started += _ => { doubleShotController.StartShot(); };
            controls.SpaceBattle.Shot.canceled += _ =>  { doubleShotController.StopShot(); };
            controls.SpaceBattle.AddForce.started += _ => { inertialMovementController.EnableEngine();};
            controls.SpaceBattle.AddForce.canceled += _ => {  inertialMovementController.DisableEngine();};

        }
        private void OnShot()
        {
        }
        
        
        private void FixedUpdate()
        {
            float moveInputX = controls.SpaceBattle.Rotate.ReadValue<Vector2>().x;
            inertialRotationController.Rotate(moveInputX);
        }
    }
    
}