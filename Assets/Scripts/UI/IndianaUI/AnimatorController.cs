using System;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private enum Layer
    {
        TopWalk=0,
        DownWalk,
        SideWalk
    }

    [SerializeField] private Layer _layer;
    private void Start()
    {
        GetComponent<Animator>().SetLayerWeight((int)_layer,1);
    }
}
