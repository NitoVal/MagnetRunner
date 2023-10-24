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
    public float RemainingTime { get; set; }


    // Start is called before the first frame update
    private void Awake()
    {

    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
