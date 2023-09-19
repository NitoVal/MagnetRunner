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

    Vector2 mousePos;
    [SerializeField] Transform point;

    //Called when instance is loaded in the scene
    private void Awake()
    {
        //Get Component
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        grCheck = gameObject.transform.GetChild(0);
        grMask = LayerMask.GetMask("Ground");

        //Initializing Input
        InputManager.onMove += OnMovePlayer;
        InputManager.onJumpPressed += Jump;
        InputManager.onCrouchPressed += Crouch;
        InputManager.onCrouchCanceled += CancelCrouch;
    }

    private void Update()
    {   
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //Flip the player when changing x direction
        if (x > 0 && !isFacingRight)
            Flip();
        if (x < 0 && isFacingRight)
            Flip();
    }
    private void FixedUpdate()
    {
        //Move the player horizontally
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }
    private void LateUpdate()
    {
        Vector2 dir = mousePos - (Vector2)point.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg - 90f;
        point.rotation = Quaternion.Euler(0f,0f,angle);
    }
    private void OnMovePlayer(float dir)
    {
        x = dir;
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180f, 0);
    }
    private bool isGrounded() { return Physics2D.OverlapCircle(grCheck.position, grCheckRadius, grMask); } //Check if the GroundCheck hits the ground
    private void Jump()
    {
        if (isGrounded())
            rb.velocity = Vector2.up * jumpForce;
        //play animation
    }
    private void Crouch()
    {
        //play animation
        transform.localScale -= new Vector3(0, 0.5f, 0);
    }
    private void CancelCrouch()
    {
        //play animation
        transform.localScale += new Vector3(0,.5f,0);
    }
}
