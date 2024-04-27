using System;
using System.Collections.Generic;
using System.Linq;
using MiniGames.ServiceLocatorModule;
using UnityEngine;
using ILogger = MiniGames.LoggerModule.ILogger;

namespace MiniGames
{
    public abstract class GameManagerBase:InitializeableMono
    {
        protected List<IService> _serviceMonoBehaviours;
        public static GameManagerBase Instance { get; private set; }
        protected void RegisterServices()
        {
            _serviceMonoBehaviours = FindObjectsOfType<MonoBehaviour>().OfType<IService>().ToList();
            foreach (var service in _serviceMonoBehaviours)
            {
                ServiceLocator.Register(service);
            }
        }
        protected void UnRegisterServices()
        {
            foreach (var service in _serviceMonoBehaviours)
            {
                ServiceLocator.UnRegister(service);
            }
        }

        protected void OnApplicationQuit()
        {
            UnRegisterServices();
        }

        public override void Init()
        {
            if (Instance == null)
            {
                Instance = this;
                RegisterServices();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}