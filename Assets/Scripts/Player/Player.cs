using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float interactRadius = 1f;
    public Key Pkey;
    LayerMask interactLayer;
    void Awake()
    {
        Pkey = null;
        interactLayer = LayerMask.GetMask("Interactable");

        InputManager.onInteract += Interact;
    }
    private void OnDisable()
    {
        InputManager.onInteract -= Interact;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Key key = other.gameObject.GetComponent<Key>();
        if (key != null && Pkey is null)
        {
            Pkey = key;
            other.gameObject.SetActive(false);
        }
        Door door = other.gameObject.GetComponent<Door>();
        if (door != null && door.doorType is Door.ActivationType.Key)
        {
            if (Pkey != null)
            {
                if (door.keyType == Pkey.GetKeyType() && !door.isOpen)
                {
                    Pkey = null;
                    door.OpenDoor();
                }
            }
        }
    }
    void Interact()
    {
        Collider2D interactable = Physics2D.OverlapCircle(transform.position, interactRadius, interactLayer);
        if (interactable)
        {
            ButtonInteractable button = interactable.GetComponent<ButtonInteractable>();
            if (button != null && !button.isActivated)
                button.Activate();

            LeverInteractable lever = interactable.GetComponent<LeverInteractable>();
            if (lever != null)
            {
                if (!lever.isUp)
                    lever.LeverUp();
                else
                    lever.LeverDown();
            }
        }
    }
}
