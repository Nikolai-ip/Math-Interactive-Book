using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    enum LayerName
    {
        Fas,
        Back,
        Side
    }
    private Dictionary<Vector2, LayerName> _layerNamesMap = new()
    {
        { new Vector2(1, 0), LayerName.Side },
        { new Vector2(-1, 0), LayerName.Side },
        { new Vector2(0, 1), LayerName.Back },
        { new Vector2(0, -1), LayerName.Fas }
    };
    

    private Animator _animator; 
    private Rigidbody2D _rb;
    [SerializeField] private float _dieAnimationForce;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(Vector2 moveDir)
    {
        moveDir = moveDir.normalized;
        SetLayerWeight(moveDir);
        ChangeAnimationByMove(moveDir);
    }

    private void SetLayerWeight(Vector2 moveDir)
    {
        if (_layerNamesMap.TryGetValue(moveDir, out LayerName layerName))
        {
            _animator.SetLayerWeight((int)layerName,1);
            SetWeightOtherLayersToZero(layerName);
        }
    }

    private void SetWeightOtherLayersToZero(LayerName exception)
    {
        foreach (var kvp in _layerNamesMap)
        {
            if (kvp.Value!= exception)
                _animator.SetLayerWeight((int)kvp.Value,0);
        }
    }

    private void ChangeAnimationByMove(Vector2 moveDir)
    {
        bool isWalk = moveDir != Vector2.zero;
        _animator.SetBool("IsWalk",isWalk);
    }

    public void PlayDieAnimation()
    {
        _rb.gravityScale = 2;
        _rb.AddForce(Vector2.up*_dieAnimationForce);
        _animator.SetTrigger("Die");
    }

    public void RestartAnimator()
    {
        _animator.SetTrigger("Restart");
    }

    public void PlayWinAnimation()
    {
        _animator.SetTrigger("Win");
    }
}
