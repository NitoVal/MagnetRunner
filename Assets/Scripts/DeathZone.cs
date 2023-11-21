using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //Attribute
    [Header("Needed Components")]
    [SerializeField] LevelManager levelManager;
    // Methods
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            levelManager.onLose?.Invoke();
        }
    }
}
