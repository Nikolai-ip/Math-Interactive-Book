using MiniGames;
using MiniGames.AudioSystem;
using MiniGames.ServiceLocatorModule;
using UnityEngine;

public class MusicController : InitializeableMono
{

    public override void Init()
    {
        ServiceLocator.Get<AudioService>().PlaySound("BackGround");
    }


}
