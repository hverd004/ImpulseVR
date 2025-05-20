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
    private bool stickDownLastFrame = false;
    private float upThreshold = 0.7f;

    public static event System.Action OnXPressed;
    public static event System.Action OnYPressed;
    public static event System.Action OnJoystickUp;
    public static event System.Action OnJoystickDown;

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
        //stick up
        bool stickUp = stick.y > upThreshold;

        if (stickUp && !stickUpLastFrame)
        {
            Debug.Log("Thumbstick moved UP!");
            OnJoystickUp?.Invoke();
        }

        stickUpLastFrame = stickUp;

        //stick down
        bool stickDown = stick.y < (-upThreshold);
        if (stickDown && !stickDownLastFrame)
        {
            Debug.Log("Thumbstick moved !");
            Debug.Log("Thumbstick moved own!");
            OnJoystickDown?.Invoke();
        }

        stickUpLastFrame = stickDown;
    }

    private void OnButtonXPressed(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();
        Debug.Log("Trigger pressed with value: " + value);
        OnXPressed?.Invoke();
    }

    private void OnButtonYPressed(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();
        Debug.Log("Trigger pressed with value: " + value);
        OnYPressed?.Invoke();
    }
}
