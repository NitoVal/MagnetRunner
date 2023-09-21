using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagnet : MonoBehaviour
{
    PlayerInput input;

    [SerializeField] Transform holder;
    float range = 5f, lerpSpeed = 100f, throwForce = 20f, pushForce = 200f;

    Rigidbody2D grabbedRB;
    Collider2D grabbedCollider;
    void Awake()
    {
        //Get Input component
        input = GetComponent<PlayerInput>();       
        
        InputManager.onSwitchPolarity += SwitchPolarity;
        InputManager.onMagnetOn += Activatemagnet;
        InputManager.onMagnetOff += StopMagnet;

        //Set layer of current gameObject
        gameObject.layer = LayerMask.NameToLayer("N");


    }

    private void StopMagnet()
    {
        if (grabbedRB)
        {
            grabbedCollider.isTrigger = false;
            grabbedCollider = null;

            grabbedRB.isKinematic = false;
            grabbedRB.interpolation = RigidbodyInterpolation2D.None;
            grabbedRB.AddForce(holder.up * throwForce, ForceMode2D.Impulse);
            grabbedRB = null;
        }
    }

    private void Activatemagnet()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - holder.position;
        RaycastHit2D hit = Physics2D.Raycast(holder.position, dir, range);
        if (hit.collider != null && hit.collider.attachedRigidbody)
        {
            //Check if layer of hit object is different of current gameobject
            if (LayerMask.LayerToName(hit.collider.gameObject.layer) == LayerMask.LayerToName(gameObject.layer))
            {
                //Push the object away
                hit.collider.attachedRigidbody.AddForce(dir * pushForce, ForceMode2D.Force);
            }
            else
            {
                //Get the Rigidbody2D of hit object
                grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }

    private void SwitchPolarity()
    {
        if (LayerMask.LayerToName(gameObject.layer) != "S")
            gameObject.layer = LayerMask.NameToLayer("S");
        else
            gameObject.layer = LayerMask.NameToLayer("N");
    }
    private void FixedUpdate()
    {
        //if the grabbed object has a Rigidbody2D pull the object towards the holder 
        if (grabbedRB)
        {
            grabbedCollider = grabbedRB.gameObject.GetComponent<Collider2D>();
            grabbedCollider.isTrigger = true;

            grabbedRB.isKinematic = true;
            grabbedRB.velocity = Vector2.zero;
            grabbedRB.interpolation = RigidbodyInterpolation2D.Interpolate;
            grabbedRB.MovePosition(Vector2.Lerp(grabbedRB.position, holder.position,Time.deltaTime * lerpSpeed));
        }
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay( holder.position, holder.up * range, Color.green);
    }
}
