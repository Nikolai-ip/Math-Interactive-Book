using System;

namespace MiniGames
{
    public interface IDieable
    {
        void Die();
        event Action Died;
    }
}