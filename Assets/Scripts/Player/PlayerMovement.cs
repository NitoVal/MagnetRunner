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
    }
    void OnDisable()
    {
        InputManager.onMove -= OnMovePlayer;
        InputManager.onJumpPressed -= Jump;
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jumpable") || other.gameObject.CompareTag("Box"))
            IsGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jumpable"))
            IsGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Vector2 difference = (transform.position - other.transform.position).normalized;
            Vector2 force = difference * 30f;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
