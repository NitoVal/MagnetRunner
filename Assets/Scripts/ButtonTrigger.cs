using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public static event Action onButtonHit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            onButtonHit?.Invoke();
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
