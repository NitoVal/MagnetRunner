using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float speed;
    public Transform door;

    public Vector2 doorStartPos;
    public Vector2 doorTranslatePos;
    public Vector2 doorEndPos;
    List<Collider2D> results = new List<Collider2D>();

    private void Awake()
    {
        doorStartPos = door.position;
        doorEndPos = (Vector2)door.position + doorTranslatePos;
    }
    private void FixedUpdate()
    {
        if (results.Count > 0)
        {
            door.position = Vector2.MoveTowards(door.position, doorEndPos, Time.deltaTime * speed);
        }
        else
        {
            door.position = Vector2.MoveTowards(door.position, doorStartPos, Time.deltaTime * speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody)
        {
            results.Add(other);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody)
        {
            results.Remove(other);
        }
    }
}
