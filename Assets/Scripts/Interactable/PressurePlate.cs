using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public static event Action<int?> onPressingPlate;
    public static event Action<int?> onReleasingPlate;
    public int id;
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.Singleton.PlaySound("OpenDoor");
        onPressingPlate?.Invoke(id);
        CameraEffects.Singleton.ShakeCamera(0.5f, 5f);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onReleasingPlate?.Invoke(id);
    }
}
