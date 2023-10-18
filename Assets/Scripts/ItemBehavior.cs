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
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collision");
            levelManager.ItemCollected++;
            collectibleNumber.text = levelManager.ItemCollected.ToString();
            Destroy(this.gameObject);
        }
    }
}

