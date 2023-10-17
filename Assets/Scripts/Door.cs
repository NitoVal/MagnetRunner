using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IDoor
{
    //private Animator animator;
    public enum DoorType
    {
        PressurePlate,
        Key,
        TriggerArea,
        Button
    }
    [HideInInspector] public DoorType doorType;

    [HideInInspector] public Key.KeyType keyType; //only when door type is a Key
    [HideInInspector] public Collider2D triggerArea; //only when door type is a TriggerArea
    [HideInInspector] public int id; //only when door type is a Button or a PressurePlate

    [HideInInspector] public bool isOpen = false;
    void Awake()
    {
        //animator = GetComponent<Animator>();

        if (doorType is DoorType.PressurePlate)
        {
            PressurePlate.ToggleOn += OpenDoor;
            PressurePlate.ToggleOff += CloseDoor;
        }
        if (doorType is DoorType.Button)
        {
            ButtonInteractable.OnButtonActivated += OpenDoor;
            ButtonInteractable.OnButtonDeactivated += CloseDoor;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorType is DoorType.TriggerArea)
        {
            if (triggerArea.IsTouching(collision) && collision.CompareTag("Player"))
            {
                OpenDoor();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (doorType is DoorType.TriggerArea)
        {
            if (collision.CompareTag("Player"))
            {
                CloseDoor();
            }
        }

    }
    public void OpenDoor()
    {
        isOpen = true;
        Debug.Log($"Opening Door: {gameObject.name}");
        //animator.SetBool("Open", isOpen);
    }
    public void CloseDoor()
    {
        isOpen = false;
        Debug.Log($"Closing Door: {gameObject.name}");
        //animator.SetBool("Open", isOpen);
    }
}
