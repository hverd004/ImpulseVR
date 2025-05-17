using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    private InputAction xButtonAction;
    private InputAction yButtonAction;

    private InputAction thumbstickAction;
    private bool stickUpLastFrame = false;
    private float upThreshold = 0.7f;

    void OnEnable()
    {
        var map = inputActions.FindActionMap("Controller", true);
        xButtonAction = map.FindAction("Pressed X", true);
        xButtonAction.performed += OnButtonXPressed;
        yButtonAction = map.FindAction("Pressed Y", true);
        yButtonAction.performed += OnButtonYPressed;
        thumbstickAction = map.FindAction("Joystick Moved", true);

        xButtonAction.Enable();
        yButtonAction.Enable();
        thumbstickAction.Enable();
    }

    void OnDisable()
    {
        xButtonAction.performed -= OnButtonXPressed;
        xButtonAction?.Disable();
        yButtonAction.performed -= OnButtonYPressed;
        yButtonAction?.Disable();
        thumbstickAction?.Disable();
    }

    void Update()
    {
        Vector2 stick = thumbstickAction.ReadValue<Vector2>();
        bool stickUp = stick.y > upThreshold;

        if (stickUp && !stickUpLastFrame)
        {
            Debug.Log("Thumbstick moved UP!");
            // Fire your one-shot action here
        }

        stickUpLastFrame = stickUp;
    }

    private void OnButtonXPressed(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();
        Debug.Log("Trigger pressed with value: " + value);
    }

    private void OnButtonYPressed(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();
        Debug.Log("Trigger pressed with value: " + value);
    }
}
