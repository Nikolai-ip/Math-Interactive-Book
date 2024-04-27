using System;
using System.Collections;
using MiniGames.AudioSystem;
using MiniGames.ServiceLocatorModule;
using UnityEngine;

public class FinallyCutScene : MonoBehaviour
{
    private IndianaInputController _inputController;
    private Player _player;
    private PlayerMoveController _playerMoveController;
    private PlayerAnimator _playerAnimator;
    [SerializeField] private GameObject _goal;
    [SerializeField] private bool _devTool;
    [SerializeField] private Transform _playerGoalTr;
    [SerializeField] private float _ditanceToPlayWinSound;
    private void Start()
    {
        _inputController = FindObjectOfType<IndianaInputController>();
        _player = FindObjectOfType<Player>();
        _playerAnimator = _player.GetComponent<PlayerAnimator>();
        _playerMoveController = _player.GetComponent<PlayerMoveController>();
    }

    public void StartCutScene()
    {
        _inputController.enabled = false;
        ServiceLocator.Get<AudioService>().SlowMuteSound("BackGround");
        StartCoroutine(MovePlayerToGoal());
    }

    private IEnumerator MovePlayerToGoal()
    {
        Transform playerTr = _player.transform;
        Transform goalTr = _goal.transform;
        var delay = new WaitForFixedUpdate();
        bool winSongIsPlaying = false;
        while (Vector2.Distance(playerTr.position, goalTr.position) > 0.1f)
        {
            Vector2 dir = (goalTr.position - playerTr.position).normalized;
            _playerMoveController.Move(dir);
            if (Vector2.Distance(playerTr.position, goalTr.position) < _ditanceToPlayWinSound && !winSongIsPlaying)
            {
                winSongIsPlaying = true;
                ServiceLocator.Get<AudioService>().PlaySound("Win");
            }
            yield return delay;
        }
        SetGoalAsPlayerChild(goalTr);
        _playerAnimator.PlayWinAnimation();
    }

    private void SetGoalAsPlayerChild(Transform goalTr)
    {
        goalTr.SetParent(_playerGoalTr);
        _playerGoalTr.position = Vector3.zero;
        float goalHeight = _goal.GetComponent<Collider2D>().bounds.size.y;
        goalTr.position = new Vector3(0, goalHeight/2);
    }
    private void OnGUI()
    {
        if (_devTool)
        {
            if (GUI.Button(new Rect(0, 60, 100, 50), "StartCutScene"))
            {
                StartCutScene();
            }
        }
    }
}
