namespace MiniGames.AudioSystem
{
    public class PersistentAudioService:AudioService
    {
        private static PersistentAudioService _instance;
        public static PersistentAudioService Instance=>_instance;
        public override void Init()
        {
            if (AudioSourcesMap.Count>0)
                return;
            base.Init();
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}