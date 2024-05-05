using MiniGames.ServiceLocatorModule;

namespace MiniGames
{
    public interface IPauseService:IService
    {
        public void StartGame();
        public void PauseGame();
    }
}