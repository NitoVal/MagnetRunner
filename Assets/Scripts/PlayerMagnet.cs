using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagnet : MonoBehaviour
{
    PlayerInput input;

    [SerializeField] Transform holder;
    float range = 5f, lerpSpeed = 10f, throwForce = 25f, pushForce = 200f;

    Rigidbody2D grabbedRB;
    Collider2D grabbedCollider;

    string old_tag;

    void Awake()
    {
        //Get Input component
        input = GetComponent<PlayerInput>();       
        
        InputManager.onSwitchPolarity += SwitchPolarity;
        InputManager.onMagnetOn += Activatemagnet;
        InputManager.onMagnetOff += StopMagnet;

        //Set layer of current gameObject
        gameObject.layer = LayerMask.NameToLayer("N");

        //set color of player based on polarity
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    private void OnDisable()
    {
        InputManager.onSwitchPolarity -= SwitchPolarity;
        InputManager.onMagnetOn -= Activatemagnet;
        InputManager.onMagnetOff -= StopMagnet;
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
                //Push the object
                hit.collider.attachedRigidbody.AddForce(dir * pushForce, ForceMode2D.Force);
            }
            else
            {
                grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                grabbedCollider = grabbedRB.gameObject.GetComponent<Collider2D>();
                old_tag = grabbedRB.tag;
                grabbedRB.tag = "Untagged";
            }
        }
    }
    private void StopMagnet()
    {
        if (grabbedRB)
        {
            grabbedRB.transform.SetParent(null);

            grabbedRB.isKinematic = false;
            grabbedRB.interpolation = RigidbodyInterpolation2D.None;
            grabbedRB.AddForce(holder.up * throwForce, ForceMode2D.Impulse);
            grabbedRB.tag = old_tag;
            old_tag = "";
            grabbedRB = null;
        }
    }
    private void SwitchPolarity()
    {
        if (LayerMask.LayerToName(gameObject.layer) != "S")
        {
            gameObject.layer = LayerMask.NameToLayer("S");
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("N");
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
    private void FixedUpdate()
    {
        //if the grabbed object has a Rigidbody2D pull the object towards the holder 
        if (grabbedRB)
        {
            if (!grabbedCollider.IsTouching(holder.GetComponent<Collider2D>()))
            {
                grabbedRB.isKinematic = true;
                grabbedRB.velocity = Vector2.zero;
                grabbedRB.interpolation = RigidbodyInterpolation2D.Interpolate;
                grabbedRB.MovePosition(Vector2.Lerp(grabbedRB.position, holder.position,Time.deltaTime * lerpSpeed));
            }
        }
    }
    private void LateUpdate()
    {
        if (grabbedRB)
        {
            if (grabbedCollider.IsTouching(holder.GetComponent<Collider2D>()))
            {
                grabbedRB.transform.position = holder.position;
                grabbedRB.transform.SetParent(holder.transform, true);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay( holder.position, holder.up * range, Color.green);
    }
}
