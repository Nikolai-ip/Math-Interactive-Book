using UnityEngine;

public class FlagAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void RiseFlag()
    {
        _animator.SetTrigger("Rise");
    }
}
