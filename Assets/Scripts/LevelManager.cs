using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    // Constantes
    const byte OBJECTIF_MAX = 1;
    const byte ITEMS_MAX = 5;


    // Attributes
    private byte itemCollected = 0;
    private byte goalItemCollected = 0;
    private float remainingTime = 50f;
    private bool timerEnable = false;
    public UnityEvent onWin;
    public UnityEvent onLose;
    [SerializeField] TMP_Text timer;


    // Getter / Setteer
    public byte ItemCollected 
    {
        get { return itemCollected; }
        set 
        { 
            itemCollected = value; 

            if (itemCollected == ITEMS_MAX)
            {
                Debug.Log("All item collected");
            }
        }
    }

    public byte GoalItemCollected
    {
        get { return goalItemCollected; }
        set
        {
            goalItemCollected = value;

            if (goalItemCollected == OBJECTIF_MAX)
            {
                onWin?.Invoke();
            }
        }
    }

    public float RemainingTime 
    { 
        get { return remainingTime; }
        set 
        {
            remainingTime = value;

            if (remainingTime <= 0)
            {
                onLose?.Invoke();
            }
        }
    }
    private void Start()
    {
        timerEnable = true;
    }

    // Methods
    private void Update()
    {
        if (timerEnable)
        {
            if (remainingTime > 0)
            {
                RemainingTime -= Time.deltaTime;
                float minute = Mathf.FloorToInt(remainingTime / 60);
                float second = Mathf.FloorToInt(remainingTime % 60);
                timer.text = string.Format("{0:00}" + ":" + "{1:00}", minute, second);
            }
        }
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Win");
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        timerEnable = false;
        remainingTime = 0;
        Debug.Log("Lose");
    }
}
