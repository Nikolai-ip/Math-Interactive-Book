using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGames
{
    public class PauseGameController : MonoBehaviour,IPauseService
    {
        [SerializeField] private UnityEvent GamePaused;
        [SerializeField] private UnityEvent GameStarted;
        public void StartGame()
        {
            Time.timeScale = 1;
            GameStarted.Invoke();
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            GamePaused.Invoke();
        }
        
    }
}

