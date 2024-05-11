using System;
using MiniGames.AudioSystem;
using MiniGames.ServiceLocatorModule;
using UnityEngine;

namespace MedievelGame
{
    public class MusicController : MonoBehaviour
    {
        private void Start()
        {
            ServiceLocator.Get<PersistentAudioService>().PlaySound("Background").SetVolume("Background",0.4f);
        }
    }

}
