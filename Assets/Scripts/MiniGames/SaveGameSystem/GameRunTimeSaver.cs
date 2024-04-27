using System;
using System.Collections.Generic;
using System.Linq;
using MiniGames.ServiceLocatorModule;
using UnityEngine;
using ILogger = MiniGames.LoggerModule.ILogger;

namespace SaveGame
{
    public class GameRunTimeSaver:MonoBehaviour, ISaver
    {
        private List<ISaveable> _saveableObjects = new();
        private List<Dictionary<string, object>> _saveDataMap = new();

        public void SaveGame()
        {
            _saveableObjects.Clear();
            _saveDataMap.Clear();
            _saveableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToList();
            foreach (var saveableObject in _saveableObjects)
            {
                var data = saveableObject.GetDataForSave();
                ServiceLocator.Get<ILogger>().WriteLog(data);
                _saveDataMap.Add(data);
            }
        }

        public void LoadGame()
        {
            for (int i = 0; i < _saveableObjects.Count; i++)
            {
                _saveableObjects[i].LoadData(_saveDataMap[i]);
            }
        }
    }
}