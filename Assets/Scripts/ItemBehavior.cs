using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class ItemBehavior : MonoBehaviour
{
    //Attribute
    [Header("Needed Components")]
    [SerializeField] TMP_Text collectibleNumber;
    [SerializeField] LevelManager levelManager;


    //Methods
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.name != "Goal")
            {
                Debug.Log("Collected");
                levelManager.ItemCollected++;
                collectibleNumber.text = levelManager.ItemCollected.ToString();
                levelManager.RemainingTime += 5f;
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Goal obtained");
                levelManager.GoalItemCollected++;
                Destroy(gameObject);
            }
        }
    }
}

