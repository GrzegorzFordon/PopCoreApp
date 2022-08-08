using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Inputs : MonoBehaviour
{
    public static Inputs main;
    public static Vector2 stickLeft;
    public static Vector2 stickRight;
    public static bool shoulderLeft;
    public static bool shoulderRight;
    public static bool triggerLeft;
    public static bool triggerRight;
    public static bool buttonNorth;
    public static bool buttonEast;
    public static bool buttonSouth;
    public static bool buttonWest;

    public static float triggerLeftValue;
    public static float triggerRightValue;

    public static bool arrowUp;
    public static bool arrowRight;
    public static bool arrowDown;
    public static bool arrowLeft;

    public Camera mainCam;
    public static Vector2 pointerPos { get { return Pointer.current.position.ReadValue(); } }
    public static Vector2 pointerDelta { get { return Pointer.current.delta.ReadValue(); } }
    public static bool pointerPress { get { return Pointer.current.press.ReadValue() > 0; } }


    private void Awake()
    {
        main = this;
        mainCam = Camera.main;
    }


    public void OnStickLeft(InputAction.CallbackContext value)
    {
        stickLeft = value.ReadValue<Vector2>();
    }
    public void OnStickRight(InputAction.CallbackContext value)
    {
        stickRight = value.ReadValue<Vector2>();
    }
    public void OnShoulderLeft(InputAction.CallbackContext value)
    {
        shoulderLeft = value.ReadValueAsButton();
    }
    public void OnShoulderRight(InputAction.CallbackContext value)
    {
        shoulderRight = value.ReadValueAsButton();
    }
    public void OnTriggerLeft(InputAction.CallbackContext value)
    {
        triggerLeft = value.ReadValueAsButton();
        triggerLeftValue = value.ReadValue<float>();
    }
    public void OnTriggerRight(InputAction.CallbackContext value)
    {
        triggerRight = value.ReadValueAsButton();
        triggerRightValue = value.ReadValue<float>();
    }
    public void OnButtonNorth(InputAction.CallbackContext value)
    {
        buttonNorth = value.ReadValueAsButton();
    }
    public void OnButtonEast(InputAction.CallbackContext value)
    {
        buttonEast = value.ReadValueAsButton();
    }
    public void OnButtonSouth(InputAction.CallbackContext value)
    {
        buttonSouth = value.ReadValueAsButton();
    }
    public void OnButtonWest(InputAction.CallbackContext value)
    {
        buttonWest = value.ReadValueAsButton();
    }
    public void OnArrowUp(InputAction.CallbackContext value)
    {
        arrowUp = value.ReadValueAsButton();
    }
    public void OnArrowRight(InputAction.CallbackContext value)
    {
        arrowRight = value.ReadValueAsButton();
    }
    public void OnArrowDown(InputAction.CallbackContext value)
    {
        arrowDown = value.ReadValueAsButton();
    }
    public void OnArrowLeft(InputAction.CallbackContext value)
    {
        arrowLeft = value.ReadValueAsButton();
    }
}
