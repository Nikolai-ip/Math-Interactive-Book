using MiniGames.MedivelAngryBirds.Scripts.Gun;
using UnityEngine;

public class MousePositionController : MonoBehaviour
{
    [SerializeField] private GunRotateController _gunRotateController;
    [SerializeField] private Camera _camera;
    private void FixedUpdate()
    {
        _gunRotateController.Rotate(_camera.ScreenToWorldPoint(Input.mousePosition));
    }
}
