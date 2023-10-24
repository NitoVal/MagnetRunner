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
        if (other.gameObject.CompareTag("Player"))
        {
            onPressingPlate?.Invoke(id);
        }
        //animator.SetBool("OnPressed", true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onReleasingPlate?.Invoke(id);
        }

        //animator.SetBool("OnPressed", false);
    }
}
