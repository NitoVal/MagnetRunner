using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float x;

    float speed = 10f;
    float jumpForce = 16f;
    bool isFacingRight = true;

    Rigidbody2D rb;

    float grCheckRadius = 0.1f;
    Transform grCheck;
    LayerMask grMask;

    PlayerInput input;
    public PlayerInputActions actions;

    //Called when instance is loaded in the scene
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        grCheck = gameObject.transform.GetChild(0);
        grMask = LayerMask.NameToLayer("Ground");

        actions = new PlayerInputActions();
        actions.Enable();
        actions.Player.Jump.performed += Jump;
        actions.Player.Crouch.performed += Crouch;
        actions.Player.Crouch.canceled += CancelCrouch;
    }

    private void Update()
    {
        x = actions.Player.Movement.ReadValue<float>();

        if (x > 0 && !isFacingRight)
            Flip();
        if (x < 0 && isFacingRight)
            Flip();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180f, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }
    private bool isGrounded() { return Physics2D.OverlapCircle(grCheck.position, grCheckRadius, grMask); }
    private void Jump(InputAction.CallbackContext obj)
    {
        //play animation
        if (isGrounded())
            rb.velocity = Vector2.up * jumpForce;
    }
    private void Crouch(InputAction.CallbackContext obj)
    {
        //play animation
        transform.localScale -= new Vector3(0, 0.5f, 0);
    }
    private void CancelCrouch(InputAction.CallbackContext obj)
    {
        //play animation
        transform.localScale += new Vector3(0,.5f,0);
    }
}
