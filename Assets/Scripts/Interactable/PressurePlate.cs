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
    public List<Rigidbody2D> list;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.attachedRigidbody)
            return;
        list.Add(other.attachedRigidbody);
        AudioManager.Singleton.PlaySound("OpenDoor");
        onPressingPlate?.Invoke(id);
        CameraEffects.Singleton.ShakeCamera(0.5f, 5f);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        list.Remove(other.attachedRigidbody);
        if (list.Count > 0)
            return;

        onReleasingPlate?.Invoke(id);
    }
}
