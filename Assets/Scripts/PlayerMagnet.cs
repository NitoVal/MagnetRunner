using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagnet : MonoBehaviour
{
    PlayerInput input;
    public PlayerInputActions actions;

    [SerializeField] Transform holder;
    float range = 5f;
    void Awake()
    {
        input = GetComponent<PlayerInput>();
        actions = new PlayerInputActions();
        actions.Enable();
        actions.Player.SwitchPolarity.performed += SwitchPolarity;
        actions.Player.Activatemagnet.performed += Activatemagnet;
        gameObject.layer = LayerMask.NameToLayer("N");
    }

    private void Activatemagnet(InputAction.CallbackContext obj)
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - holder.position;
        RaycastHit2D hit = Physics2D.Raycast(holder.position, dir, range);
        if (hit.collider != null)
        {
            //Check if layer of hit object is different of gameobject
            if (true)
            {
                //Attract object
            }
            else
            {
                //Repulse gameobject
            }
        }
    }

    private void SwitchPolarity(InputAction.CallbackContext obj)
    {
        switch (LayerMask.LayerToName(gameObject.layer))
        {
            case "N":
                gameObject.layer = LayerMask.NameToLayer("S");
                break;
            case "S":
                gameObject.layer = LayerMask.NameToLayer("N");
                break;
            default:
                break;
        }
    }
}
