using System;
using System.Collections.Generic;

namespace MiniGames.ServiceLocatorModule
{
    public class ServiceLocator
    {
        private static Dictionary<Type, IService> _servicesMap = new Dictionary<Type, IService>();
        public static void Register<T>(T service) where T : IService
        {
            var type = service.GetType();
            if (_servicesMap.ContainsKey(type))
            {
                throw new Exception("The service already exist in the dictionary");
            }
            _servicesMap.Add(type, service);
        }

        public static void UnRegister<T>(T service) where T : IService
        {
            var type = service.GetType();
            if (_servicesMap.ContainsKey(type))
            {
                _servicesMap.Remove(type);
            }
        }

        public static T Get<T>() where T : IService
        { 
            Type type = typeof(T);
            foreach (var kvp in _servicesMap)
            {
                if (kvp.Key == type || type.IsAssignableFrom(kvp.Key))
                {
                    return (T)kvp.Value;
                }
            }
            return default;
        }
    }
}