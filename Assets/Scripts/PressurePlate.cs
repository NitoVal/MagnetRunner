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
    //public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.Singleton.PlaySound("OpenDoor");
        onPressingPlate?.Invoke(id);
        CameraEffects.Singleton.ShakeCamera(1f, 10f);
        //animator.SetBool("isPressed", true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onReleasingPlate?.Invoke(id);
        //animator.SetBool("isPressed", false);
    }
}
