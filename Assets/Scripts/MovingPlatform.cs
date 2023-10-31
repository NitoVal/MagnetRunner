using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    public float speed;
    public float intervalBetweenPoint; //in seconds

    float temp;
    public List<Rigidbody2D> rbList;
    private void Awake()
    {
        transform.position = waypoints[0].transform.position;
    }
    void Update()
    {
        CheckDistance();
    }
    private void FixedUpdate()
    {
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
        other.gameObject.transform.SetParent(transform, true);
        if (other.attachedRigidbody != null && !other.CompareTag("Player"))
        {
            rbList.Add(other.attachedRigidbody);
            other.attachedRigidbody.interpolation = RigidbodyInterpolation2D.Extrapolate;
        }
        else
            return;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.transform.SetParent(null);
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
            rbList.Remove(other.attachedRigidbody);
        }
    }
}
