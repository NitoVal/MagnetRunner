using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IDoor
{
    public enum ActivationType
    {
        PressurePlate,
        Key,
        TriggerArea,
        Button,
        Lever
    }
    [HideInInspector] public ActivationType doorType;
    [HideInInspector] public Key.KeyType keyType; //only when door type is a Key
    [HideInInspector] public Collider2D triggerArea; //only when door type is a TriggerArea
    [HideInInspector] public int id; //only when door type is a Button, a PressurePlate or a Lever

    [HideInInspector] public bool isOpen = false;

    Vector2 startPos;
    public Vector2 endPos;
    
    void Awake()
    {
        startPos = transform.position;
        endPos.x = transform.position.x;
        if (doorType is ActivationType.PressurePlate)
        {
            PressurePlate.onPressingPlate += OpenDoor; 
            PressurePlate.onReleasingPlate += CloseDoor;
        }
        if (doorType is ActivationType.Button)
        {
            ButtonInteractable.OnButtonActivated += OpenDoor;
            ButtonInteractable.OnButtonDeactivated += CloseDoor;
        }
        if (doorType is ActivationType.Lever)
        {
            LeverInteractable.OnLeverUp += OpenDoor;
            LeverInteractable.OnLeverDown += CloseDoor;
        }
    }
    private void Update()
    {
        if (isOpen)
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime * 40f); //Toutes les portes se ferment slowly
        else
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.deltaTime * 4f); //Toutes les portes s'ouvrent vite
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorType is ActivationType.TriggerArea)
        {
            if (triggerArea.IsTouching(collision) && collision.CompareTag("Player"))
            {
                OpenDoor();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (doorType is ActivationType.TriggerArea)
        {
            if (collision.CompareTag("Player"))
            {
                CloseDoor();
            }
        }
    }
    public void OpenDoor(int? id)
    {
        if (this.id != id)
            return;

        isOpen = true;
        Debug.Log($"Opening Door: {gameObject.name}");
    } //only for pressure plate, button and lever door type
    public void OpenDoor()
    {
        isOpen = true;
        Debug.Log($"Opening Door: {gameObject.name}");
    } //for all types of doors
    public void CloseDoor(int? id)
    {
        if (this.id != id)
            return;

        isOpen = false;
        Debug.Log($"Closing Door: {gameObject.name}");
    } //only for pressure plate, button and lever door type
    public void CloseDoor()
    {
        isOpen = false;
        Debug.Log($"Closing Door: {gameObject.name}");
    } //for all types of doors
}
