namespace MiniGames.ServiceLocatorModule
{
    public interface ISaver:IService
    {
        void LoadGame();
        void SaveGame();
    }
}