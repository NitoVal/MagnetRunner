using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float x; 

    float speed = 10f;
    float jumpForce = 20f;

    bool isFacingRight = true;
    bool IsGrounded;
    Rigidbody2D rb;

    PlayerInput input;

    Vector2 mousePos;
    [SerializeField] Transform point;
    [SerializeField] Transform playerTransform;

    //Called when instance is loaded in the scene
    private void Awake()
    {
        //Get components
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();

        //Initializing input
        InputManager.onMove += OnMovePlayer;
        InputManager.onJumpPressed += Jump;
        InputManager.onCrouchPressed += Crouch;
        InputManager.onCrouchCanceled += CancelCrouch;
    }
    void OnDisable()
    {
        InputManager.onMove -= OnMovePlayer;
        InputManager.onJumpPressed -= Jump;
        InputManager.onCrouchPressed -= Crouch;
        InputManager.onCrouchCanceled -= CancelCrouch;
    }
    private void Update()
    {   
        //Get mouse position 
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

        //Rotate holder object
        Vector2 dir = mousePos - (Vector2)point.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        point.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void OnMovePlayer(float dir) { x = dir; }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        playerTransform.Rotate(0, 180f, 0);
    }
    private void Jump()
    {
        if (IsGrounded)
            rb.velocity = Vector2.up * jumpForce;
        //play animation
    }
    private void Crouch()
    {
        //play animation
        transform.localScale -= new Vector3(0,5, 0);
        this.transform.position -= new Vector3(0,0.6f,0);
    } //TO REDO
    private void CancelCrouch()
    {
        //play animation
        transform.localScale += new Vector3(0,5f,0);
        this.transform.position += new Vector3(0,0.5f, 0);
    } //TO REDO
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jumpable"))
            IsGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jumpable"))
            IsGrounded = false;
    }
}
