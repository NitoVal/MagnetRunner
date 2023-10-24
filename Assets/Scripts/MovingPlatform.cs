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
    public float intervalBetweenPoint;

    float temp;
    Rigidbody2D p;
    void Update()
    {
        if (p != null)
        {
            if (p.velocity.x != 0)
                p.gameObject.transform.SetParent(null);
            else
                p.gameObject.transform.SetParent(transform);
        }
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
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            p = collision.attachedRigidbody;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
            p = null;
        }
    }
}
