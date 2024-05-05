using System.Collections;
using MiniGames;
using UnityEngine;

namespace SpaceBattle
{
    public class PlayerShip:Player
    {
        [SerializeField] private InputControllerBase _inputController;
        protected override void Die()
        {
            base.Die();
            _inputController.enabled = false;
        }

        public void OnWin()
        {
            _inputController.enabled = false;
            GetComponent<InertialMovementController>().enabled = false;
            GetComponent<InertialRotationController>().enabled = false;
            StartCoroutine(RotateShipToInitial());
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        private IEnumerator RotateShipToInitial()
        {
            float time = 0;
            float duration = 5;
            while (time<duration)
            {
                time += Time.deltaTime;
                transform.eulerAngles = new Vector3(0,0,Mathf.LerpAngle(transform.eulerAngles.z, 0, time/duration));
                yield return null;
            }
        }
    }
}