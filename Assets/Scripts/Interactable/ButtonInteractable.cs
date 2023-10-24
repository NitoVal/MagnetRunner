using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractable : MonoBehaviour
{
    public float timer;
    public int id;

    [HideInInspector] public bool isActivated;

    public static event Action<int?> OnButtonActivated;
    public static event Action<int?> OnButtonDeactivated;
    //public Animator animator;
    public void Activate()
    {
        isActivated = true;
        OnButtonActivated?.Invoke(id);
        Invoke("Deactivate", timer);
        //animator.SetBool("Activated", isActivated);
    }
    public void Deactivate()
    {
        isActivated = false;
        OnButtonDeactivated?.Invoke(id);
        //animator.SetBool("Activated", isActivated);
    }
}
