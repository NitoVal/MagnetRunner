using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    public bool isAutomatic;

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
        if (rbList != null)
        {
            foreach (Rigidbody2D rbP in rbList)
            {
                rbP.interpolation = RigidbodyInterpolation2D.Extrapolate;
                if (rbP.velocity.x != 0)
                    rbP.gameObject.transform.SetParent(null, true);
                else
                    rbP.gameObject.transform.SetParent(transform, true);
            }
        }
        if (isAutomatic)
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
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.SetParent(transform, true);
        if (other.attachedRigidbody)
        {
            rbList.Add(other.attachedRigidbody);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.transform.SetParent(null, true);
        if (other.attachedRigidbody)
        {
            rbList.Remove(other.attachedRigidbody);
        }
    }
}
