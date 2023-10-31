using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Attributes
    private byte itemCollected = 0;
    private float remainingTime = 1000f;

    public byte ItemCollected 
    {
        get { return itemCollected; }
        set { itemCollected = value; }
    }
    public float RemainingTime 
    { 
        get { return remainingTime; }
        set { }
    }

    private void Awake()
    {

    }

    private void Start()
    {
        
    }
    private void Update()
    {

    }
}
