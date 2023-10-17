using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractable : MonoBehaviour
{
    public float timer;
    public int id;

    [HideInInspector] public bool isActivated;

    public static event Action OnButtonActivated;
    public static event Action OnButtonDeactivated;
    //public Animator animator;
    public void Activate()
    {
        isActivated = true;
        OnButtonActivated?.Invoke();
        Invoke("Deactivate", timer);
        //animator.SetBool("Activated", isActivated);
    }
    void Deactivate()
    {
        isActivated = false;
        OnButtonDeactivated?.Invoke();
        //animator.SetBool("Activated", isActivated);
    }
}
