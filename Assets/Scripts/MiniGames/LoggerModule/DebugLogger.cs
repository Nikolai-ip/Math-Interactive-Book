using System.Collections;
using UnityEngine;

namespace MiniGames.LoggerModule
{
    public class DebugLogger:MonoBehaviour,ILogger
    {
        [SerializeField] private bool _writeLogs;
        public void WriteLog(object data)
        {
            if (!_writeLogs) return;
            if (data is IEnumerable enumerable)
            {
                ShowCollection(enumerable);
            }
            else
            {
                Debug.Log(data);
            }
        }

        private void ShowCollection(IEnumerable collection)
        {
            foreach (var elem in collection)
            {
                Debug.Log(elem);
            }
        }
    }
}