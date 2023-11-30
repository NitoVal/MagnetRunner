using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class ItemBehavior : MonoBehaviour
{
    //Attribute
    [Header("Needed Components")]
    public TMP_Text collectibleNumber;
    public LevelManager levelManager;


    //Methods
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!gameObject.CompareTag("RecompenseFin"))
            {
                AudioManager.Singleton.PlaySound("Collectible");
                levelManager.ItemCollected++;
                collectibleNumber.text = levelManager.ItemCollected.ToString();
                levelManager.RemainingTime += 5f;
                Destroy(gameObject);
            }
            else
            {
                levelManager.GoalItemCollected++;
                Destroy(gameObject);
            }
        }
    }
}

