using UnityEngine;

namespace MiniGames
{
    public abstract class InitializeableMono:MonoBehaviour,IInitializable
    {
        public abstract void Init();
    }
}