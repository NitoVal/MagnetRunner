using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteractable : MonoBehaviour
{
    public int id;
    [HideInInspector] public bool isUp = false;

    public static event Action<int?> OnLeverUp;
    public static event Action<int?> OnLeverDown;
    public void LeverUp() 
    {
        isUp = true;
        OnLeverUp?.Invoke(id);
    }
    public void LeverDown()
    {
        isUp = false;
        OnLeverDown?.Invoke(id);
    }
}
