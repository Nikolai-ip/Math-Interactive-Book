using System;
using MiniGames;
using MiniGames.AudioSystem;
using MiniGames.ServiceLocatorModule;
using UnityEngine;

public class PlayerAudioController : InitializeableMono
{
    [SerializeField] private float _walkVolume;

    public void OnMove(Vector2 move)
    {
        if (move != Vector2.zero)
        {
            ServiceLocator.Get<AudioService>().PlaySound("Walk");
        }
    }

    public override void Init()
    {
        ServiceLocator.Get<AudioService>().SetVolume("Walk", _walkVolume);
    }
}
