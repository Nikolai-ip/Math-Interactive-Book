using System.Collections.Generic;
using MiniGames;
using MiniGames.SaveGameSystem;
using SaveGame;
using UnityEngine;

namespace Indiana
{
    public class Player : InitializeableMono, IDamageable, ISaveable, ISaveableEntityTrigger
    {
        [SerializeField] private float _health;
        private Collider2D _playerCollider;
        private Rigidbody2D _playerRb;
        private PlayerAnimator _playerAnimator;
        private FlickerController _flickerController;
        
        private Dictionary<string, object> SavedData = new()
        {
            { "Position", Vector2.zero }
        };
        public void TakeDamage(GameObject damager, float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Die();
            }
        }
        private void Die()
        {
            _playerCollider.enabled = false;
            _playerAnimator.PlayDieAnimation();
            GameManager.GetInstance().Lose();
        }
    
        public void Reborn()
        {
            _playerRb.gravityScale = 0;
            _playerRb.velocity = Vector2.zero;
            _playerCollider.enabled = true;
            _playerAnimator.RestartAnimator();
            _flickerController.StartFlick();
        }
        public Dictionary<string, object> GetDataForSave()
        {
            SavedData["Position"] = transform.position;
            return SavedData;
        }
        public void LoadData(Dictionary<string, object> savedData)
        {
            Vector2 savedPosition = (Vector3)savedData["Position"];
            transform.position = savedPosition;
        }
    
        public override void Init()
        {
            _flickerController = GetComponent<FlickerController>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerRb = GetComponent<Rigidbody2D>();
            _playerCollider = GetComponent<Collider2D>();
        }
    }

}
