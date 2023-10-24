using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Events;
using UnityEditor.SearchService;

public class InputManager : MonoBehaviour
{
    public PlayerInputActions actions;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    public static event Action<float> onMove;
    public static event Action onJumpPressed;
    public static event Action onCrouchPressed;
    public static event Action onCrouchCanceled;
    public static event Action onSwitchPolarity;
    public static event Action onMagnetOn;
    public static event Action onMagnetOff;
    public static event Action onInteract;
    public UnityEvent onPause;
    public UnityEvent onResume;
    private bool isPaused;

   

    void OnEnable()
    {
        isPaused = false;
        Time.timeScale = 1.0f;

        actions.Player.Enable();

        actions.Player.Movement.performed += OnMovePressed;
        actions.Player.Movement.canceled += OnMovePressed;

        actions.Player.Jump.performed += OnJumpPressed;

        actions.Player.Crouch.performed += OnCrouchPressed;
        actions.Player.Crouch.canceled += OnCrouchCanceled;

        actions.Player.SwitchPolarity.performed += OnSwitchPolarity;

        actions.Player.Activatemagnet.performed += OnActivateMagnet;
        actions.Player.Activatemagnet.canceled += OnStopMagnet;

        actions.Player.Interact.performed += OnInteract;
    }
    void OnDisable()
    {
        actions.Player.Movement.performed -= OnMovePressed;
        actions.Player.Movement.canceled -= OnMovePressed;

        actions.Player.Jump.performed -= OnJumpPressed;

        actions.Player.Crouch.performed -= OnCrouchPressed;
        actions.Player.Crouch.canceled -= OnCrouchCanceled;

        actions.Player.SwitchPolarity.performed -= OnSwitchPolarity;

        actions.Player.Activatemagnet.performed -= OnActivateMagnet;
        actions.Player.Activatemagnet.canceled -= OnStopMagnet;

        actions.Player.Interact.performed -= OnInteract;
        actions.Player.Disable();
    }
    private void OnInteract(InputAction.CallbackContext obj)
    {
        onInteract?.Invoke();
    }
    private void OnMovePressed(InputAction.CallbackContext obj)
    {
        onMove?.Invoke(obj.ReadValue<float>());
    }
    private void OnCrouchCanceled(InputAction.CallbackContext obj)
    {
        onCrouchCanceled?.Invoke();
    }
    private void OnStopMagnet(InputAction.CallbackContext obj)
    {
        onMagnetOff?.Invoke();
    }
    public void OnJumpPressed(InputAction.CallbackContext obj)
    {
        onJumpPressed?.Invoke();
    }
    public void OnSwitchPolarity(InputAction.CallbackContext obj)
    {
        onSwitchPolarity?.Invoke();
    }
    public void OnActivateMagnet(InputAction.CallbackContext obj)
    {
        onMagnetOn?.Invoke();
    }
    public void OnCrouchPressed(InputAction.CallbackContext obj)
    {
        onCrouchPressed?.Invoke();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (!isPaused)
            {
                isPaused = true;
                onPause?.Invoke();
            }
            else
            {
                isPaused = false;
                onResume?.Invoke();
            }
        }
    }

    private void Update()
    {
        PauseGame();
    }

    
}
