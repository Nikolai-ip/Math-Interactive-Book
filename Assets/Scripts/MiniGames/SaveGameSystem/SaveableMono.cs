using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveGame
{
    public abstract class SaveableMono:MonoBehaviour,ISaveable
    {
        protected Dictionary<string, object> SavedData;

        protected virtual void Start()
        {
            SavedData = new Dictionary<string, object>()
            {
                { "Sender", this },
            };
        }

        public abstract Dictionary<string, object> GetDataForSave();

        public abstract void LoadData(Dictionary<string, object> savedData);

    }
}