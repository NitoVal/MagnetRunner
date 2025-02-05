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
        Lever,
        ButtonCollision
    }
    [HideInInspector] public ActivationType doorType;
    [HideInInspector] public Key.KeyType keyType; //only when door type is a Key
    [HideInInspector] public int id; //only when door type is a Button, a PressurePlate or a Lever

    [HideInInspector] public bool isOpen = false;

    Vector2 startPos;
    public Vector2 endPos;
    [Range(10f, 20f)]
    public float speed;
    [Range(1, 15)]
    public int closingSpeed;
    void Awake()
    {
        startPos = transform.position;
        endPos.x = transform.position.x;
        endPos.y += transform.position.y;
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
        if (doorType is ActivationType.ButtonCollision)
        {
            ButtonTrigger.onButtonHit += OpenDoor;
        }
    }
    private void Update()
    {
        if (isOpen)
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime * speed); 
        else
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.deltaTime * speed/closingSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorType is ActivationType.TriggerArea)
        {
            if (collision.CompareTag("Player"))
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
    } //only for pressure plate, button and lever door type
    public void OpenDoor()
    {
        isOpen = true;
    } //for all types of doors
    public void CloseDoor(int? id)
    {
        if (this.id != id)
            return;

        isOpen = false;
    } //only for pressure plate, button and lever door type
    public void CloseDoor()
    {
        isOpen = false;
    } //for all types of doors
}
