using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float interactRadius = 1f;
    /// <summary>
    /// TODO:
    /// Change so that the player can only have 1 key
    /// </summary>
    [SerializeField] List<Key.KeyType> keyList;
    LayerMask interactLayer;
    void Awake()
    {
        keyList = new List<Key.KeyType>();
        
        interactLayer = LayerMask.GetMask("Interactable");

        InputManager.onInteract += Interact;
    }
    public bool ContainKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Key key = other.GetComponent<Key>();
        if (key != null)
        {
            keyList.Add(key.GetKeyType());
            Destroy(other.gameObject);
        }

        Door door = other.GetComponent<Door>();
        if (door != null)
        {
            if (door.doorType is Door.DoorType.Key)
            {
                if (ContainKey(door.keyType) && !door.isOpen)
                {
                    keyList.Remove(door.keyType);
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
            if (lever != null && !lever.isUp)
                lever.LeverUp();
            else
                lever.LeverDown();
        }
    }
}
