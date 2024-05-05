using UnityEngine;

namespace MiniGames
{
    public abstract class PoolObject:MonoBehaviour
    {
        public abstract void Init();
        public virtual void Activated(){gameObject.SetActive(true);}
        public virtual void Deactivated(){gameObject.SetActive(false);}
    }
}