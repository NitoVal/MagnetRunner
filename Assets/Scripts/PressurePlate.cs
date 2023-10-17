using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public static event Action ToggleOn;
    public static event Action ToggleOff;
    public int id;
    //public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        ToggleOn?.Invoke();
        //animator.SetBool("OnPressed", true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        ToggleOff?.Invoke();
        //animator.SetBool("OnPressed", false);
    }
}
