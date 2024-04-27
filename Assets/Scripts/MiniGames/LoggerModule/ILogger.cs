using MiniGames.ServiceLocatorModule;

namespace MiniGames.LoggerModule
{
    public interface ILogger:IService
    {
        void WriteLog(object data);
    }
}