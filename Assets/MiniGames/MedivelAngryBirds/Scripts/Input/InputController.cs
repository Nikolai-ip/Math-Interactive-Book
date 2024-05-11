using System;
using MiniGames;
using MiniGames.MedivelAngryBirds.Scripts.Gun;
using UnityEngine;

namespace MedievelGame
{
    public class InputController : InitializeableMono
    {
        [SerializeField] private GunRotateController _gunRotateController;
        [SerializeField] private GunShotController _gunShotController;
        private Camera _camera;

        private void Start()
        {
            _camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _gunRotateController.Rotate(mousePos);
            if (Input.GetMouseButtonDown(0))
            {
                _gunShotController.Shot();
            }
        }

        public override void Init()
        {
        }
    }

}
