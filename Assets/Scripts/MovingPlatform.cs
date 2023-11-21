using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [Range(5f, 15f)]
    public float speed;

    [Range(0, 3f)]
    public float intervalBetweenPoint;

    float temp;
    List<Rigidbody2D> rbList;
    private void Awake()
    {
        transform.position = waypoints[0].transform.position;
        rbList = new List<Rigidbody2D>();
    }
    void Update()
    {
        CheckDistance();
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
    private void CheckDistance()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            if (temp <= intervalBetweenPoint)
                temp += Time.deltaTime;
            else
            {
                temp = 0;
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                    currentWaypointIndex = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundCheck"))
            return;
        other.gameObject.transform.SetParent(transform, true);
        if (other.attachedRigidbody != null)
        {
            rbList.Add(other.attachedRigidbody);
            other.attachedRigidbody.interpolation = RigidbodyInterpolation2D.Extrapolate;
        }
        else
            return;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundCheck"))
            return;
        other.gameObject.transform.SetParent(null);
        if (other.attachedRigidbody != null)
        {
           other.attachedRigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
           rbList.Remove(other.attachedRigidbody);
        }
        else
           return;
    }
    private void OnApplicationQuit()
    {
        transform.DetachChildren();
    }
}
