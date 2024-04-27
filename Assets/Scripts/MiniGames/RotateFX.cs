using System.Collections;
using UnityEngine;

public class RotateFX
{
     public enum RotationDirection
     {
          Clockwise,
          CounterClockwise
     }

     public void Rotate(MonoBehaviour rotated, float angle, float duration, RotationDirection direction)
     {
          rotated.StartCoroutine(RotateCoroutine(rotated.transform, angle, duration, direction));
     }

     private IEnumerator RotateCoroutine(Transform rotated, float angle, float duration, RotationDirection direction)
     {
          Quaternion startRotation = rotated.rotation;
          Quaternion endRotation = Quaternion.Euler(rotated.eulerAngles + (direction == RotationDirection.Clockwise ? Vector3.forward : Vector3.back) * angle);
          float elapsedTime = 0f;

          while (elapsedTime < duration)
          {
               rotated.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
               elapsedTime += Time.deltaTime;
               yield return null;
          }

          rotated.rotation = endRotation;
     }
}
