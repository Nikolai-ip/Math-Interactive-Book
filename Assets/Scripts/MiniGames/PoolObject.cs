using UnityEngine;

namespace MiniGames
{
    public abstract class PoolObject:MonoBehaviour
    {
        public abstract void Init();
        public abstract void Activated();
        public abstract void Deactivated();
    }
}