using UnityEngine;

namespace MiniGames.MedivelAngryBirds.Scripts.Block
{
    public class BlockDivider : MonoBehaviour
    {
        [SerializeField] private Block[] _zeroRankParticles;
        [SerializeField] private Block[] _firstRankParticles;
        [SerializeField] private Block[] _secondRankParticles;
        [SerializeField] private float _firstRankEnableForce;
        [SerializeField] private float _secondRankEnableForce;
        private Block[][] _particles;
    
        private void Awake()
        {
            InitParticles();
            EnableParticles(_zeroRankParticles);
        }
    
        public void HandleHitForce(float force)
        {
            if (force > _secondRankEnableForce)
            {
                EnableParticles(_secondRankParticles);
                return;
            }
            if (force > _firstRankEnableForce)
            {
                EnableParticles(_firstRankParticles);
            }
        }
    
        private void EnableParticles(Block[] particles)
        {
            DisableAllParticles();
            foreach (var particle in particles)
            {
                particle.Enable();
            }
        }
    
        private void DisableParticles(Block[] particles)
        {
            foreach (var particle in particles)
            {
                particle.Disable();
            }
        }
    
        private void DisableAllParticles()
        {
            for (int i = 0; i < _particles.GetLength(0); i++)
            {
                DisableParticles(_particles[i]);
            }
        }
        private void InitParticles()
        {
            _particles = new Block[3][];
            _particles[0] = _zeroRankParticles;
            _particles[1] = _firstRankParticles;
            _particles[2] = _secondRankParticles;
            for (int i = 0; i < _particles.Length; i++)
            {
                for (int j = 0; j < _particles[i].Length; j++)
                {
                    _particles[i][j].Init();
                }   
            }
        }

    }
}

