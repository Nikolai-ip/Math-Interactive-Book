using MiniGames.AudioSystem;
using MiniGames.ServiceLocatorModule;
using SpaceBattle;
using UnityEngine;

public class EndCutScene : MonoBehaviour
{
    [SerializeField] private float _delayToPlayWinSong;
    [SerializeField] private float _delayToPlayWinAnimation;
    [SerializeField] private PlayerShipAnimator _playerAnimator;
    public void OnWon()
    {
        ServiceLocator.Get<AudioService>().SlowMuteSound("BackGround");
        
        Invoke(nameof(PlayWinSong),_delayToPlayWinSong);
        Invoke(nameof(PlayWinAnimation),_delayToPlayWinAnimation);

    }

    private void PlayWinSong()
    {
        ServiceLocator.Get<AudioService>().PlaySound("Win");
    }

    private void PlayWinAnimation()
    {
        _playerAnimator.PlayWinAnimation();
    }
}
