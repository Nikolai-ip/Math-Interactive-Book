using System;
using System.Collections.Generic;
using System.Linq;
using MiniGames.ServiceLocatorModule;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGames
{
    public class GameManagerBase:InitializeableMono
    {
        protected static List<IService> serviceMonoBehaviours;
        public static GameManagerBase Instance { get; private set; }
        protected void RegisterServices()
        {
            serviceMonoBehaviours = FindObjectsOfType<MonoBehaviour>().OfType<IService>().ToList();
            foreach (var service in serviceMonoBehaviours)
            {
                ServiceLocator.Register(service);
            }
        }
        protected void UnRegisterServices()
        {
            foreach (var service in serviceMonoBehaviours)
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
            if (!IsFirstLaunchGame())
                UnRegisterServices();
            RegisterServices();
            if (Instance == null)
            {
                Instance = this;
            }
            else if (gameObject!=Instance.gameObject)
            {
                Destroy(gameObject);
            }
        }

        public bool IsFirstLaunchGame()
        {
            return ServiceLocator.GetEnumerable().Count() == 0;
        }
    }
}